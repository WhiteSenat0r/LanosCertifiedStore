using AutoMapper;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using LanosCertifiedStore.Persistence.Queries.Common.Contracts;
using LanosCertifiedStore.Persistence.Queries.VehicleRelated.QueryRelated.Common;

namespace LanosCertifiedStore.Persistence.Queries.VehicleRelated.QueryRelated;

public sealed class CollectionVehiclesQuery(
    ApplicationDatabaseContext context,
    IQueryFilteringCriteriaSelector<Vehicle> filteringCriteriaSelector,
    IQuerySortingSettingsSelector<Vehicle> sortingSettingsSelector,
    IQueryPaginator queryPaginator,
    IMapper mapper) : CollectionVehiclesQueryBase<VehicleDto>(
    context,
    filteringCriteriaSelector,
    sortingSettingsSelector,
    queryPaginator,
    mapper);
