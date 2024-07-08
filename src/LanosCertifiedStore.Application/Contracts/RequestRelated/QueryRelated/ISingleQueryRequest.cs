using Application.Shared.ResultRelated;
using MediatR;

namespace Application.Contracts.RequestRelated.QueryRelated;

public interface ISingleQueryRequest<TRequestResult>
    : IRequest<Result<TRequestResult>> where TRequestResult : class
{
    Guid ItemId { get; }
}