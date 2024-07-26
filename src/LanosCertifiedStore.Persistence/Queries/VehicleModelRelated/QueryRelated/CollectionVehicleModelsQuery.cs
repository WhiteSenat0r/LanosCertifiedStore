using AutoMapper;
using LanosCertifiedStore.Application.VehicleModels.Dtos;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using LanosCertifiedStore.Persistence.Queries.Common.Contracts;
using LanosCertifiedStore.Persistence.Queries.VehicleModelRelated.QueryRelated.Common;

namespace LanosCertifiedStore.Persistence.Queries.VehicleModelRelated.QueryRelated;

public sealed class CollectionVehicleModelsQuery(
    ApplicationDatabaseContext context,
    IQueryFilteringCriteriaSelector<VehicleModel> filteringCriteriaSelector,
    IQuerySortingSettingsSelector<VehicleModel> sortingSettingsSelector,
    IQueryPaginator queryPaginator,
    IMapper mapper) : CollectionVehicleModelsQueryBase<VehicleModelDto>(
    context, 
    filteringCriteriaSelector,
    sortingSettingsSelector,
    queryPaginator,
    mapper);