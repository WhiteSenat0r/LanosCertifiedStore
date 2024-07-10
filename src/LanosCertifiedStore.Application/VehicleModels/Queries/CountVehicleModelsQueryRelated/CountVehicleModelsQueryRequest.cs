using Application.Shared.RequestParamsRelated;
using Application.Shared.RequestRelated.QueryRelated;
using Domain.Entities.VehicleRelated;

namespace Application.VehicleModels.Queries.CountVehicleModelsQueryRelated;

public sealed record CountVehicleModelsQueryRequest(
    IFilteringRequestParameters<VehicleModel> FilteringParameters) : 
    ICountQueryRequest<VehicleModel>;