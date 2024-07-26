using AutoMapper;
using AutoMapper.QueryableExtensions;
using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Domain.Contracts.Common;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace LanosCertifiedStore.Persistence.Queries.Common.Classes.QueryBaseRelated;

public abstract class SingleQueryBase<TEntity, TDto>(
    ApplicationDatabaseContext context,
    IMapper mapper)
    where TEntity : class, IIdentifiable<Guid>
    where TDto : class, IIdentifiable<Guid>
{
    public async Task<TDto?> Execute(
        ISingleQueryRequest<TDto> queryRequest,
        CancellationToken cancellationToken)
    {
        var queryable = GetDatabaseQueryable();

        var executionResult = await GetQueryResult(queryable, queryRequest, cancellationToken);

        return executionResult;
    }

    private IQueryable<TEntity> GetDatabaseQueryable()
    {
        var dataSet = context.Set<TEntity>();

        return dataSet.AsQueryable();
    }

    private async Task<TDto?> GetQueryResult(
        IQueryable<TEntity> queryable,
        ISingleQueryRequest<TDto> queryRequest,
        CancellationToken cancellationToken)
    {
        var item = await queryable
            .ProjectTo<TDto>(mapper.ConfigurationProvider)
            .AsNoTracking()
            .SingleOrDefaultAsync(i => i.Id.Equals(queryRequest.ItemId), cancellationToken);

        return item;
    }
}