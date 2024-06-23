using Application.Contracts.RepositoryRelated.Common;
using Domain.Contracts.Common;
using MediatR;

namespace Application.Contracts.RequestRelated.QueryRelated;

public interface IQueryRequest<TModel, TQueryResult, TRequestResult> : IRequest<TRequestResult>
    where TModel : IIdentifiable<Guid>
    where TQueryResult : notnull
    where TRequestResult : notnull
{
    IFilteringRequestParameters<TModel> FilteringParameters { get; }
    bool IsTracked { get; }
}