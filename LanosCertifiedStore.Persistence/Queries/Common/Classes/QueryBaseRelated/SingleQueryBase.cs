using Application.Contracts.RequestRelated.QueryRelated;
using Application.Shared.ResultRelated;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Contracts.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;

namespace Persistence.Queries.Common.Classes.QueryBaseRelated;

public abstract class SingleQueryBase<TEntity, TDto>(
    ApplicationDatabaseContext context,
    IMapper mapper)
    where TEntity : class, IIdentifiable<Guid>
    where TDto : class, IIdentifiable<Guid>
{
    public async Task<TDto?> Execute<TRequestResult>(
        IQueryRequest<TEntity, TRequestResult> queryRequest,
        CancellationToken cancellationToken)
        where TRequestResult : notnull
    {
        var queryable = GetDatabaseQueryable();

        var singleQueryRequest = (queryRequest as ISingleQueryRequest<TEntity, Result<TDto>>)!; // TODO fix transforming queryRequest value to null due to cast
        var executionResult = await GetQueryResult(queryable, singleQueryRequest, cancellationToken);

        return executionResult;
    }

    private IQueryable<TEntity> GetDatabaseQueryable()
    {
        var dataSet = context.Set<TEntity>();

        return dataSet.AsQueryable();
    }

    private async Task<TDto?> GetQueryResult(
        IQueryable<TEntity> queryable,
        ISingleQueryRequest<TEntity, Result<TDto>> queryRequest,
        CancellationToken cancellationToken)
    {
        var item = await queryable
            .ProjectTo<TDto>(mapper.ConfigurationProvider)
            .AsNoTracking()
            .SingleOrDefaultAsync(i => i.Id.Equals(queryRequest.ItemId), cancellationToken);

        return item;
    }
}