using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestRelated.QueryRelated;
using Application.Dtos.Common;
using Application.Shared;
using Domain.Contracts.Common;

namespace Application.Queries.Common.CountItemsQueryRelated;

public abstract record CountItemsQueryRequestBase<TModel, TQueryResult, TRequestResult>(
    IFilteringRequestParameters<TModel> FilteringParameters,
    bool IsTracked) : ICountQueryRequest<TModel, TQueryResult, TRequestResult>
    where TModel : class, IIdentifiable<Guid>
    where TQueryResult : Tuple<int, int>
    where TRequestResult : Result<ItemsCountDto>;