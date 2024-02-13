using Domain.Contracts.Common;
using Domain.Contracts.RepositoryRelated;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Repositories.Common.QuerySpecificationRelated;

namespace Persistence.Repositories.Common.Classes;

internal abstract class GenericRepository<TEntity>(
    ApplicationDatabaseContext dbContext) : IRepository<TEntity>
    where TEntity : class, IEntity<Guid>
{
    protected internal ApplicationDatabaseContext Context { get; init; } = 
        dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public Task<List<TEntity>> GetAllEntitiesAsync
        (IQuerySpecification<TEntity> querySpecification) =>
        ApplySpecification(querySpecification).ToListAsync();

    public Task<TEntity> GetSingleEntityBySpecificationAsync
        (IQuerySpecification<TEntity> querySpecification) =>
        ApplySpecification(querySpecification).SingleOrDefaultAsync()!;

    public async Task AddNewEntityAsync(TEntity entity) => 
        await Context.Set<TEntity>().AddAsync(entity);

    public async Task AddNewRangeOfEntitiesAsync(IEnumerable<TEntity> entities) => 
        await Context.Set<TEntity>().AddRangeAsync(entities);

    public void UpdateExistingEntity(TEntity updatedEntity) => 
        Context.Set<TEntity>().Update(updatedEntity);

    public void UpdateRangeOfExistingEntities(IEnumerable<TEntity> updatedEntities) => 
        Context.Set<TEntity>().UpdateRange(updatedEntities);

    public virtual void RemoveExistingEntity(TEntity removedEntity) => 
        Context.Set<TEntity>().Remove(removedEntity);

    public virtual void RemoveRangeOfExistingEntities(IEnumerable<TEntity> removedEntities) => 
        Context.Set<TEntity>().RemoveRange(removedEntities);

    public Task<int> CountAsync(IQuerySpecification<TEntity> querySpecification) => 
        Context.Set<TEntity>().Where(querySpecification.Criteria).CountAsync();

    private IQueryable<TEntity> ApplySpecification(IQuerySpecification<TEntity> querySpecification) =>
        QuerySpecificationEvaluator.GetQuerySpecifications(Context.Set<TEntity>(), querySpecification);
}
