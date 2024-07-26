using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Domain.Contracts.Common;
using MediatR;

namespace LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;

public interface IQueryRequest<TEntity, TRequestResult> : IRequest<TRequestResult>
    where TEntity : class, IIdentifiable<Guid>
    where TRequestResult : notnull
{
    IFilteringRequestParameters<TEntity> FilteringParameters { get; }
}