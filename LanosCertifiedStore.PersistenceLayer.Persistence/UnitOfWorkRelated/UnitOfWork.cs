using System.Collections;
using AutoMapper;
using Domain.Contracts.Common;
using Domain.Contracts.RepositoryRelated;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.UnitOfWorkRelated.Common.Classes;

namespace Persistence.UnitOfWorkRelated;

internal sealed class UnitOfWork(ApplicationDatabaseContext context, IMapper mapper) : IUnitOfWork
{
    private readonly Hashtable _repositoryInstancesHashTable = new();
    private readonly Dictionary<Type, Type> _repositoryTypeMap =
        RepositoryMappings.VehicleRelatedRepositoryMappings;

    public IRepository<TEntity> RetrieveRepository<TEntity>()
        where TEntity : IIdentifiable<Guid>
    {
        var repositoryTypeKey = typeof(TEntity).Name;

        if (_repositoryInstancesHashTable.ContainsKey(repositoryTypeKey))
            return (_repositoryInstancesHashTable[repositoryTypeKey] as IRepository<TEntity>)!;

        var repositoryAbstractionType = typeof(IRepository<TEntity>);

        var repositoryInstanceType = DeterminateRepositoryInstanceType(
            repositoryAbstractionType);

        var repositoryInstance = Activator.CreateInstance(
            repositoryInstanceType, mapper, context);

        _repositoryInstancesHashTable.Add(repositoryTypeKey, repositoryInstance);

        return (_repositoryInstancesHashTable[repositoryTypeKey] as IRepository<TEntity>)!;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => 
        context.SaveChangesAsync(cancellationToken);

    public void ClearChangeTrackerData() => context.ChangeTracker.Clear();

    public async Task DisposeAsync() => await context.DisposeAsync();
    
    private Type DeterminateRepositoryInstanceType(Type repositoryAbstractionType) =>
        _repositoryTypeMap.TryGetValue(repositoryAbstractionType, out var concreteType)
            ? concreteType
            : throw new ArgumentException(
                "Such repository abstraction type is not mapped and can't be used!");

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        context.SaveChangesAsync(cancellationToken);
}