using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;

namespace LanosCertifiedStore.Application.VehicleModels.Queries.CountVehicleModelsQueryRelated;

public sealed record CountVehicleModelsQueryRequest(
    IFilteringRequestParameters<VehicleModel> FilteringParameters) : 
    ICountQueryRequest<VehicleModel>;