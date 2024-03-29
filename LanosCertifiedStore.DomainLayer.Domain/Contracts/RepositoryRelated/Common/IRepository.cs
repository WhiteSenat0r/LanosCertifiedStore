﻿using Domain.Contracts.Common;

namespace Domain.Contracts.RepositoryRelated.Common;

public interface IRepository<TEntity> 
    where TEntity : IIdentifiable<Guid>
{
    Task<IReadOnlyList<TEntity>> GetAllEntitiesAsync(
        IFilteringRequestParameters<TEntity> filteringRequestParameters = null!);

    Task<TEntity?> GetEntityByIdAsync(Guid id);

    Task AddNewEntityAsync(TEntity entity);

    Task UpdateExistingEntityAsync(TEntity updatedEntity);

    Task RemoveExistingEntityAsync(Guid id);

    Task<int> CountAsync(IFilteringRequestParameters<TEntity>? filteringRequestParameters = null!);
}