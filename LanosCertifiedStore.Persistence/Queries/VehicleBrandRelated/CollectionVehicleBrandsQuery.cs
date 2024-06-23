using AutoMapper;
using Domain.Models.VehicleRelated.Classes;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Entities.VehicleRelated;
using Persistence.Queries.Common.Classes.QueryBaseRelated;
using Persistence.Queries.Common.Contracts;

namespace Persistence.Queries.VehicleBrandRelated;

internal sealed class CollectionVehicleBrandsQuery(
    ApplicationDatabaseContext context,
    IQueryProjectionProfileSelector<VehicleBrand, VehicleBrandEntity> projectionProfileSelector,
    IQuerySortingSettingsSelector<VehicleBrand, VehicleBrandEntity> sortingSettingsSelector,
    IQueryFilteringCriteriaSelector<VehicleBrand, VehicleBrandEntity> filteringCriteriaSelector,
    IQueryPaginator queryPaginator,
    IMapper mapper) : CollectionQueryBase<VehicleBrand, VehicleBrandEntity>(
    context,
    projectionProfileSelector,
    sortingSettingsSelector,
    filteringCriteriaSelector,
    queryPaginator,
    mapper);