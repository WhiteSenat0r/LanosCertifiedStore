using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestRelated.QueryRelated;
using Application.Core.Results;
using Application.Dtos.BrandDtos;
using Domain.Entities.VehicleRelated;

namespace Application.QueryRequests.VehicleBrandsRelated.CollectionVehicleBrandsQueryRelated;

public sealed record CollectionVehicleBrandsQueryRequest(
    IFilteringRequestParameters<VehicleBrand> FilteringParameters) : 
    ICollectionQueryRequest<VehicleBrand, PaginationResult<VehicleBrandDto>, VehicleBrandDto>;