using AutoMapper;
using Domain.Contracts.Common;
using Domain.Contracts.RepositoryRelated;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories.Common.Classes;

internal abstract class GenericRepository<TEntity, TDataModel>(
    IMapper mapper, DbContext dbContext) : IRepository<TEntity>
    where TEntity : IEntity<Guid>
    where TDataModel : class, IEntity<Guid>
{
    private protected DbContext Context { get; } = 
        dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    private protected IMapper Mapper { get; } = 
        mapper ?? throw new ArgumentNullException(nameof(mapper)); // TODO resolve why tf do we need this (Context as well)

    public abstract Task<IReadOnlyList<TEntity>> GetAllEntitiesAsync();

    public abstract Task<IReadOnlyList<TEntity>> GetAllEntitiesAsync(
        IFilteringRequestParameters<TEntity> filteringRequestParameters);

    public abstract Task<TEntity?> GetEntityByIdAsync(Guid id);

    public abstract Task AddNewEntityAsync(TEntity entity);

    public abstract void UpdateExistingEntity(TEntity updatedEntity);

    public abstract void RemoveExistingEntity(TEntity removedEntity);

    public abstract Task<int> CountAsync();
}
