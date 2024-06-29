using Application.Constants;
using Application.Contracts.RequestRelated.QueryRelated;
using Application.Contracts.ServicesRelated.RequestRelated;
using Application.Shared.ResultRelated;
using Domain.Contracts.Common;
using Persistence.Factories.QueryRelated.Common.Contracts;

namespace Persistence.Services;

internal sealed class QueryService(IQueryFactory queryFactory) : IQueryService
{
    public async Task<Result<TQueryResult>> GetResult<TModel, TQueryResult, TRequestResult>(
        IQueryRequest<TModel, TQueryResult, TRequestResult> queryRequest,
        CancellationToken cancellationToken)
        where TModel : class, IIdentifiable<Guid>
        where TQueryResult : notnull
        where TRequestResult : notnull
    {
        try
        {
            var query = queryFactory.GetQuery(queryRequest);
            var result = await query.Execute(queryRequest, cancellationToken);

            return result;
        }
        catch (Exception)
        {
            return Result<TQueryResult>.Failure(new Error(
                QueryServiceConstants.NonProcessableQueryRequestCode,
                QueryServiceConstants.NonProcessableQueryMessage));
        }
    }
}