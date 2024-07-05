using Application.Contracts.Common;
using Domain.Contracts.Common;
using MediatR;

namespace Application.Contracts.RequestRelated.QueryRelated;

public interface IQueryRequest<TEntity, TRequestResult> : IRequest<TRequestResult>
    where TEntity : class, IIdentifiable<Guid>
    where TRequestResult : notnull
{
    IFilteringRequestParameters<TEntity> FilteringParameters { get; }
}