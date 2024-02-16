using Domain.Contracts.Common;

namespace Domain.Contracts.RepositoryRelated;

public interface IRepository<TEntity> 
    where TEntity : IEntity<Guid>
{
    Task<IReadOnlyList<TEntity>> GetAllEntitiesAsync(
        IFilteringRequestParameters<TEntity> filteringRequestParameters = null!);

    Task<TEntity?> GetEntityByIdAsync(Guid id);

    Task AddNewEntityAsync(TEntity entity);

    void UpdateExistingEntity(TEntity updatedEntity);

    Task RemoveExistingEntity(Guid id);

    Task<int> CountAsync(IFilteringRequestParameters<TEntity>? filteringRequestParameters = null!);
}