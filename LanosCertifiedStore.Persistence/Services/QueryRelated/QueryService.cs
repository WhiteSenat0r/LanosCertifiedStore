using Application.Contracts.RequestRelated;
using Application.Contracts.ServicesRelated.RequestRelated;
using Domain.Contracts.Common;
using Persistence.Services.QueryRelated.Common.Contracts;

namespace Persistence.Services.QueryRelated;

internal sealed class QueryService(IQueryMappings queryMappings) : IQueryService
{
    public Task<TQueryResult> GetResult<TModel, TQueryResult, TRequestResult>(
        IQueryRequest<TModel, TQueryResult, TRequestResult> queryRequest,
        CancellationToken cancellationToken)
        where TModel : IIdentifiable<Guid>
        where TQueryResult : notnull
        where TRequestResult : notnull
    {
        throw new NotImplementedException();
    }
}