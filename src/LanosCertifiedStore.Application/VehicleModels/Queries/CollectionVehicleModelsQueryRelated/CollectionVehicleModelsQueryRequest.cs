using Application.Shared.RequestParamsRelated;
using Application.Shared.RequestRelated.QueryRelated;
using Application.Shared.ResultRelated;
using Application.VehicleModels.Dtos;
using Domain.Entities.VehicleRelated;

namespace Application.VehicleModels.Queries.CollectionVehicleModelsQueryRelated;

public sealed record CollectionVehicleModelsQueryRequest(
    IFilteringRequestParameters<VehicleModel> FilteringParameters) : 
    ICollectionQueryRequest<VehicleModel, PaginationResult<VehicleModelDto>, VehicleModelDto>;