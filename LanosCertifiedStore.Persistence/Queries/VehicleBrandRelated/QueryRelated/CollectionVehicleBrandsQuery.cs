using Application.Dtos.BrandDtos;
using AutoMapper;
using Domain.Entities.VehicleRelated;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Queries.Common.Classes.QueryBaseRelated;
using Persistence.Queries.Common.Contracts;

namespace Persistence.Queries.VehicleBrandRelated.QueryRelated;

public sealed class CollectionVehicleBrandsQuery(
    ApplicationDatabaseContext context,
    IQuerySortingSettingsSelector<VehicleBrand> sortingSettingsSelector,
    IQueryFilteringCriteriaSelector<VehicleBrand> filteringCriteriaSelector,
    IQueryPaginator queryPaginator,
    IMapper mapper) : CollectionQueryBase<VehicleBrand, VehicleBrandDto>(
    context,
    sortingSettingsSelector,
    filteringCriteriaSelector,
    queryPaginator,
    mapper);