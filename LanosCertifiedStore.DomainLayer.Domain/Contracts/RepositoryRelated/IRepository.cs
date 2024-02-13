using Domain.Contracts.Common;

namespace Domain.Contracts.RepositoryRelated;

public interface IRepository<TEntity>
    where TEntity : class, IEntity<Guid>
{
    Task<List<TEntity>> GetAllEntitiesAsync();

    Task<TEntity?> GetEntityByIdAsync(Guid id);

    Task AddNewEntityAsync(TEntity entity);

    Task AddNewRangeOfEntitiesAsync(IEnumerable<TEntity> entities);

    void UpdateExistingEntity(TEntity updatedEntity);

    void UpdateRangeOfExistingEntities(IEnumerable<TEntity> updatedEntities);

    void RemoveExistingEntity(TEntity removedEntity);

    void RemoveRangeOfExistingEntities(IEnumerable<TEntity> removedEntities);

    Task<int> CountAsync(IQuerySpecification<TEntity> querySpecification);
}