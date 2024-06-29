using Application.Shared.ResultRelated;
using Domain.Contracts.Common;

namespace Application.Contracts.RequestRelated.QueryRelated;

public interface ISingleQueryRequest<TModel, TQueryResult, TRequestResult, TDto> : 
    IQueryRequest<TModel, TQueryResult, TRequestResult>
    where TModel : class, IIdentifiable<Guid>
    where TQueryResult : TModel
    where TRequestResult : Result<TDto>
    where TDto : class
{
    Guid ItemId { get; }
}