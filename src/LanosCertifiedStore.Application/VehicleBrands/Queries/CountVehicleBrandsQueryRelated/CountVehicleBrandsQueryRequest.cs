using Application.Shared.RequestParamsRelated;
using Application.Shared.RequestRelated.QueryRelated;
using Domain.Entities.VehicleRelated;

namespace Application.VehicleBrands.Queries.CountVehicleBrandsQueryRelated;

public sealed record CountVehicleBrandsQueryRequest(
    IFilteringRequestParameters<VehicleBrand> FilteringParameters) : ICountQueryRequest<VehicleBrand>;