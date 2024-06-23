using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestRelated.QueryRelated;
using Application.Shared;
using Domain.Contracts.Common;

namespace Application.Queries.Common.SingleQueryRelated;

public abstract record SingleQueryRequestBase<TModel, TQueryResult, TRequestResult, TDto>(
    IFilteringRequestParameters<TModel> FilteringParameters,
    bool IsTracked,
    Guid ItemId) : ISingleQueryRequest<TModel, TQueryResult, TRequestResult, TDto> 
    where TModel : class, IIdentifiable<Guid>
    where TQueryResult : TModel
    where TRequestResult : Result<TDto> 
    where TDto : class;