using Application.Contracts.Common;
using Application.Contracts.RequestRelated.QueryRelated;
using Application.Dtos.BrandDtos;
using Application.Shared.ResultRelated;
using Domain.Entities.VehicleRelated;

namespace Application.QueryRequests.VehicleBrandsRelated.CollectionVehicleBrandsQueryRelated;

public sealed record CollectionVehicleBrandsQueryRequest(
    IFilteringRequestParameters<VehicleBrand> FilteringParameters) : 
    ICollectionQueryRequest<VehicleBrand, PaginationResult<VehicleBrandDto>, VehicleBrandDto>;