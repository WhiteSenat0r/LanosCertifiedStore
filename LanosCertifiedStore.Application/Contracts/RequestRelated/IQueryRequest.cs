using Application.Contracts.RepositoryRelated.Common;
using Application.Shared;
using Domain.Contracts.Common;
using MediatR;

namespace Application.Contracts.RequestRelated;

public interface IQueryRequest<TModel, TQueryResult, TRequestResult> : IRequest<Result<TRequestResult>>
    where TModel : IIdentifiable<Guid>
    where TQueryResult : notnull
    where TRequestResult : notnull
{
    IFilteringRequestParameters<TModel> FilteringParameters { get; }
    bool IsTracked { get; }
}