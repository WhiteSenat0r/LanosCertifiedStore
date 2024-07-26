using LanosCertifiedStore.Application.Shared.ResultRelated;
using MediatR;

namespace LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;

public interface ISingleQueryRequest<TRequestResult>
    : IRequest<Result<TRequestResult>> where TRequestResult : class
{
    Guid ItemId { get; }
}