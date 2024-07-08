using Application.Shared.RequestParamsRelated;
using Application.Shared.RequestRelated.QueryRelated;
using Application.Shared.ResultRelated;
using Application.VehicleBrands.Dtos;
using Domain.Entities.VehicleRelated;

namespace Application.VehicleBrands.Queries.CollectionVehicleBrandsQueryRelated;

public sealed record CollectionVehicleBrandsQueryRequest(
    IFilteringRequestParameters<VehicleBrand> FilteringParameters) : 
    ICollectionQueryRequest<VehicleBrand, PaginationResult<VehicleBrandDto>, VehicleBrandDto>;