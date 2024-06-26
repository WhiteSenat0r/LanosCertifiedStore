using Application.Dtos.Common;
using Application.Shared;
using Domain.Contracts.Common;

namespace Application.Contracts.RequestRelated.QueryRelated;

public interface ICountQueryRequest<TModel, TQueryResult, TRequestResult> : 
    IQueryRequest<TModel, TQueryResult, TRequestResult>
    where TModel : class, IIdentifiable<Guid>
    where TQueryResult : Tuple<int, int>
    where TRequestResult : Result<ItemsCountDto>;