using AutoMapper;
using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using LanosCertifiedStore.Persistence.Queries.Common.Classes.QueryBaseRelated;
using LanosCertifiedStore.Persistence.Queries.Common.Contracts;

namespace LanosCertifiedStore.Persistence.Queries.VehicleModelRelated.QueryRelated.Common;

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