using Application.Contracts.RequestRelated;
using Domain.Contracts.Common;

namespace Application.Contracts.ServicesRelated.RequestRelated;

public interface IQueryService
{
    Task<TQueryResult> GetResult<TModel, TQueryResult, TRequestResult>(
        IQueryRequest<TModel, TQueryResult, TRequestResult> queryRequest,
        CancellationToken cancellationToken)
        where TModel : IIdentifiable<Guid>
        where TQueryResult : notnull
        where TRequestResult : notnull;
}