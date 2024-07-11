using Application.Shared.RequestParamsRelated;
using Application.Shared.RequestRelated.QueryRelated;
using Application.Shared.ResultRelated;
using Application.VehicleModels.Dtos;
using Domain.Entities.VehicleRelated;

namespace Application.VehicleModels.Queries.CollectionVehicleBrandlessModelsQueryRelated;

public sealed record CollectionVehicleBrandlessModelsQueryRequest(
    IFilteringRequestParameters<VehicleModel> FilteringParameters) : 
    ICollectionQueryRequest<VehicleModel, PaginationResult<VehicleModelWithoutBrandNameDto>, VehicleModelWithoutBrandNameDto>;