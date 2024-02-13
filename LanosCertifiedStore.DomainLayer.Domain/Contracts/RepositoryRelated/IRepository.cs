using Domain.Contracts.Common;

namespace Domain.Contracts.RepositoryRelated;

public interface IRepository<TEntity> 
    where TEntity : IEntity<Guid>
{
    Task<List<TEntity>> GetAllEntitiesAsync();

    Task<TEntity?> GetEntityByIdAsync(Guid id);

    Task AddNewEntityAsync(TEntity entity);

    void UpdateExistingEntity(TEntity updatedEntity);

    void RemoveExistingEntity(TEntity removedEntity);

    Task<int> CountAsync();
}