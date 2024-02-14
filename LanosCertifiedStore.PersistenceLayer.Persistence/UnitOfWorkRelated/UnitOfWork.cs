using System.Collections;
using AutoMapper;
using Domain.Contracts.Common;
using Domain.Contracts.RepositoryRelated;
using Microsoft.EntityFrameworkCore;
using Persistence.UnitOfWorkRelated.Common.Classes;

namespace Persistence.UnitOfWorkRelated;

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _context;
    private readonly IMapper _mapper;
    private readonly Hashtable _repositoryInstancesHashTable = new();
    private readonly Dictionary<Type, Type> _repositoryTypeMap =
        RepositoryMappings.VehicleRelatedRepositoryMappings;
    
    internal UnitOfWork(DbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IRepository<TEntity> RetrieveRepository<TEntity>()
        where TEntity : IEntity<Guid>
    {
        var repositoryTypeKey = typeof(TEntity).Name;

        if (_repositoryInstancesHashTable.ContainsKey(repositoryTypeKey))
            return (_repositoryInstancesHashTable[repositoryTypeKey] as IRepository<TEntity>)!;
        
        var repositoryAbstractionType = typeof(IRepository<TEntity>);
            
        var repositoryInstanceType = DeterminateRepositoryInstanceType(
            repositoryAbstractionType);

        var repositoryInstance = Activator.CreateInstance(
            repositoryInstanceType, _context, _mapper);
            
        _repositoryInstancesHashTable.Add(repositoryTypeKey, repositoryInstance);

        return (_repositoryInstancesHashTable[repositoryTypeKey] as IRepository<TEntity>)!;
    }

    private Type DeterminateRepositoryInstanceType(Type repositoryAbstractionType) =>
        _repositoryTypeMap.TryGetValue(repositoryAbstractionType, out var concreteType)
            ? concreteType
            : throw new ArgumentException(
                "Such repository abstraction type is not mapped and can't be used!");

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => 
        _context.SaveChangesAsync(cancellationToken);
} 