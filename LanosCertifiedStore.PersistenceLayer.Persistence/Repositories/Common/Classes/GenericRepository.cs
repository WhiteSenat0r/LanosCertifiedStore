using AutoMapper;
using Domain.Contracts.Common;
using Domain.Contracts.RepositoryRelated;
using Microsoft.EntityFrameworkCore;
using Persistence.QueryEvaluation;

namespace Persistence.Repositories.Common.Classes;

internal abstract class GenericRepository<TEntity, TDataModel> : IRepository<TEntity>
    where TEntity : IEntity<Guid>
    where TDataModel : class, IEntity<Guid>
{
    private protected DbContext Context { get; }
    private protected IMapper Mapper { get; }

    private protected GenericRepository(IMapper mapper, DbContext dbContext)
    {
        Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        Context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }
    
    public abstract Task<IReadOnlyList<TEntity>> GetAllEntitiesAsync(
        IFilteringRequestParameters<TEntity>? filteringRequestParameters = null!);

    public abstract Task<TEntity?> GetEntityByIdAsync(Guid id);

    public async Task AddNewEntityAsync(TEntity entity)
    {
        var mappedEntityModel = Mapper.Map<TEntity, TDataModel>(entity);

        await Context.Set<TDataModel>().AddAsync(mappedEntityModel);
    }

    public void UpdateExistingEntity(TEntity updatedEntity)
    {
        var mappedEntityModel = Mapper.Map<TEntity, TDataModel>(updatedEntity);

        Context.Set<TDataModel>().Update(mappedEntityModel);
    }

    public async Task RemoveExistingEntity(Guid id)
    {
        var removedEntity = await Context.Set<TDataModel>().SingleOrDefaultAsync(
            entity => entity.Id.Equals(id));
        
        if (removedEntity is not null)
            Context.Set<TDataModel>().Remove(removedEntity);
    }

    public Task<int> CountAsync() => Context.Set<TDataModel>().CountAsync();

    private protected abstract IQueryable<TDataModel> GetRelevantQueryable(
        IFilteringRequestParameters<TEntity> filteringRequestParameters);

    private protected abstract BaseQueryEvaluator<TEntity, TDataModel> GetVehicleQueryEvaluator(
        IFilteringRequestParameters<TEntity>? filteringRequestParameters);
}
