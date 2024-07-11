using Application.Shared.RequestParamsRelated;
using Domain.Contracts.Common;
using MediatR;

namespace Application.Shared.RequestRelated.QueryRelated;

public interface IQueryRequest<TEntity, TRequestResult> : IRequest<TRequestResult>
    where TEntity : class, IIdentifiable<Guid>
    where TRequestResult : notnull
{
    IFilteringRequestParameters<TEntity> FilteringParameters { get; }
}