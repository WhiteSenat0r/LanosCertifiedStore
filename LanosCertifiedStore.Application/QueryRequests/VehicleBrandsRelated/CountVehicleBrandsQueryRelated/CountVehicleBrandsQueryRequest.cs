using Application.Contracts.Common;
using Application.Contracts.RequestRelated.QueryRelated;
using Domain.Entities.VehicleRelated;

namespace Application.QueryRequests.VehicleBrandsRelated.CountVehicleBrandsQueryRelated;

public sealed record CountVehicleBrandsQueryRequest(
    IFilteringRequestParameters<VehicleBrand> FilteringParameters) : 
    ICountQueryRequest<VehicleBrand>;