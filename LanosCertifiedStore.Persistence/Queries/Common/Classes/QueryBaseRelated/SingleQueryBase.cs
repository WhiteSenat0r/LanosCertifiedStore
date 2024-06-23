using Application.Contracts.RequestRelated.QueryRelated;
using Application.Shared;
using AutoMapper;
using Domain.Contracts.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Queries.Common.Classes.QueryBaseRelated.Constants;
using Persistence.Queries.Common.Contracts;
using Persistence.Queries.Common.Extensions;

namespace Persistence.Queries.Common.Classes.QueryBaseRelated;

internal abstract class SingleQueryBase<TModel, TEntity, TDto>(
    ApplicationDatabaseContext context,
    IQueryProjectionProfileSelector<TModel, TEntity> projectionProfileSelector,
    IMapper mapper) : ISingleQuery<TModel, TModel, Result<TDto>, TDto>
    where TModel : class, IIdentifiable<Guid>
    where TEntity : class, IIdentifiable<Guid>
    where TDto : class
{
    public async Task<Result<TModel>> Execute<TRequestResult>(
        IQueryRequest<TModel, TModel, TRequestResult> queryRequest,
        CancellationToken cancellationToken)
        where TRequestResult : notnull
    {
        var queryable = GetDatabaseQueryable();

        queryable = queryable.GetQueryWithAppliedSelectionProfile(
            queryRequest.FilteringParameters, projectionProfileSelector);
        queryable = queryable.GetQueryWithAppliedTrackingSettings(queryRequest.IsTracked);

        var singleQueryRequest = (queryRequest as ISingleQueryRequest<TModel, TModel, Result<TDto>, TDto>)!;
        var executionResult = await GetQueryResult(queryable, singleQueryRequest, cancellationToken);

        return executionResult;
    }

    private IQueryable<TEntity> GetDatabaseQueryable()
    {
        var dataSet = context.Set<TEntity>();
        
        return dataSet.AsQueryable();
    }
    
    private async Task<Result<TModel>> GetQueryResult<TRequestResult>(
        IQueryable<TEntity> queryable,
        ISingleQueryRequest<TModel, TModel, TRequestResult, TDto> queryRequest,
        CancellationToken cancellationToken)
        where TRequestResult : Result<TDto>
    {
        try
        {
            var item = await queryable.SingleAsync(i => i.Id.Equals(queryRequest.ItemId),cancellationToken);
            var mappedItem = mapper.Map<TEntity, TModel>(item);
            
            return Result<TModel>.Success(mappedItem);
        }
        catch (InvalidOperationException)
        {
            return Result<TModel>.Failure(
                new Error(QueryConstants.QueryExecutionErrorCode, QueryConstants.QueryNonExistingItemErrorMessage));
        }
        catch (Exception)
        {
            return Result<TModel>.Failure(
                new Error(QueryConstants.QueryExecutionErrorCode, QueryConstants.QueryExecutionErrorMessage));
        }
    }
}