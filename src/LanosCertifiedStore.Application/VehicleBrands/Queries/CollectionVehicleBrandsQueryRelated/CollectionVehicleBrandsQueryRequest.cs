using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.VehicleBrands.Dtos;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;

namespace LanosCertifiedStore.Application.VehicleBrands.Queries.CollectionVehicleBrandsQueryRelated;

public sealed record CollectionVehicleBrandsQueryRequest(
    IFilteringRequestParameters<VehicleBrand> FilteringParameters) : 
    ICollectionQueryRequest<VehicleBrand, PaginationResult<VehicleBrandDto>, VehicleBrandDto>;