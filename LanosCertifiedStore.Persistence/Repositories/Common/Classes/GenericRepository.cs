using Application.Contracts.RepositoryRelated.Common;
using AutoMapper;
using Domain.Contracts.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.QueryBuilder;

namespace Persistence.Repositories.Common.Classes;

internal abstract class GenericRepository<TSelectionProfile, TEntity, TDataModel, TParamsType> : IRepository<TEntity>
    where TSelectionProfile : struct, Enum
    where TEntity : IIdentifiable<Guid>
    where TDataModel : class, IIdentifiable<Guid>
    where TParamsType : class, IFilteringRequestParameters<TEntity>
{
    private protected readonly BaseQueryBuilder<TSelectionProfile, TEntity, TDataModel, TParamsType> QueryBuilder;
    private protected readonly DbContext Context;
    private protected readonly IMapper Mapper;

    private protected GenericRepository(
        IMapper mapper, 
        DbContext dbContext)
    {
        Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        Context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        QueryBuilder = GetQueryBuilder();
    }
    
    public abstract Task<IReadOnlyList<TEntity>> GetAllEntitiesAsync(
        IFilteringRequestParameters<TEntity>? filteringRequestParameters = null!);

    public abstract Task<TEntity?> GetEntityByIdAsync(Guid id);

    public virtual async Task AddNewEntityAsync(TEntity entity)
    {
        var mappedEntityModel = Mapper.Map<TEntity, TDataModel>(entity);

        await Context.Set<TDataModel>().AddAsync(mappedEntityModel);
    }

    public virtual async Task UpdateExistingEntityAsync(TEntity updatedEntity)
    {
        var mappedEntityModel = Mapper.Map<TEntity, TDataModel>(updatedEntity);

        Context.Set<TDataModel>().Update(mappedEntityModel);
    }

    public virtual async Task RemoveExistingEntityAsync(Guid id)
    {
        var removedEntity = await Context.Set<TDataModel>().SingleOrDefaultAsync(
            entity => entity.Id.Equals(id));
        
        if (removedEntity is not null)
        {
            Context.Set<TDataModel>().Remove(removedEntity);
        }
    }

    public abstract Task<int> CountAsync(IFilteringRequestParameters<TEntity>? filteringRequestParameters = null!);

    private protected abstract IQueryable<TDataModel> GetRelevantQueryable(
        IFilteringRequestParameters<TEntity> filteringRequestParameters);

    private protected abstract BaseQueryBuilder<TSelectionProfile, TEntity, TDataModel, TParamsType> GetQueryBuilder();
}
