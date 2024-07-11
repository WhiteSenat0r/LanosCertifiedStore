using Application.Shared.RequestRelated.QueryRelated;
using AutoMapper;
using Domain.Entities.VehicleRelated;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Queries.Common.Classes.QueryBaseRelated;
using Persistence.Queries.Common.Contracts;

namespace Persistence.Queries.VehicleModelRelated.QueryRelated.Common;

public abstract class CollectionVehicleModelsQueryBase<TDto>(
    ApplicationDatabaseContext context,
    IQueryFilteringCriteriaSelector<VehicleModel> filteringCriteriaSelector,
    IQuerySortingSettingsSelector<VehicleModel> sortingSettingsSelector,
    IQueryPaginator queryPaginator,
    IMapper mapper) : CollectionQueryBase<VehicleModel, TDto> 
    where TDto : class
{
    public sealed override async Task<IReadOnlyCollection<TDto>> Execute<TRequestResult>(
        IQueryRequest<VehicleModel, TRequestResult> queryRequest, CancellationToken cancellationToken)
    {
        var queryable = GetDatabaseQueryable(context);

        queryable = GetFilteredQueryable(queryRequest, queryable, filteringCriteriaSelector);
        queryable = GetSortedQueryable(queryRequest, queryable, sortingSettingsSelector);
        queryable = GetPaginatedQueryable(queryRequest, queryable, queryPaginator);

        var executionResult = await GetQueryResult(queryable, mapper, cancellationToken);

        return executionResult;
    }
}