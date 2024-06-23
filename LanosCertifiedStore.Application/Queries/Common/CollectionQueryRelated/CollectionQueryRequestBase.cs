using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestRelated.QueryRelated;
using Application.Core.Results;
using Application.Shared;
using Domain.Contracts.Common;

namespace Application.Queries.Common.CollectionQueryRelated;

public abstract record CollectionQueryRequestBase<TModel, TQueryResult, TRequestResult, TDto>(
    IFilteringRequestParameters<TModel> FilteringParameters,
    bool IsTracked) : ICollectionQueryRequest<TModel, TQueryResult, TRequestResult, TDto> 
    where TModel : class, IIdentifiable<Guid>
    where TQueryResult : IReadOnlyCollection<TModel>
    where TRequestResult : Result<PaginationResult<TDto>>
    where TDto : class;