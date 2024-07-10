using Application.VehicleModels.Dtos;
using AutoMapper;
using Domain.Entities.VehicleRelated;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Queries.Common.Contracts;
using Persistence.Queries.VehicleModelRelated.QueryRelated.Common;

namespace Persistence.Queries.VehicleModelRelated.QueryRelated;

public sealed class CollectionBrandlessVehicleModelsQuery(
    ApplicationDatabaseContext context,
    IQueryFilteringCriteriaSelector<VehicleModel> filteringCriteriaSelector,
    IQuerySortingSettingsSelector<VehicleModel> sortingSettingsSelector,
    IQueryPaginator queryPaginator,
    IMapper mapper) : CollectionVehicleModelsQueryBase<VehicleModelWithoutBrandNameDto>(
    context, 
    filteringCriteriaSelector,
    sortingSettingsSelector,
    queryPaginator,
    mapper);