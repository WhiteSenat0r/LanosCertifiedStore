using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;

namespace LanosCertifiedStore.Application.VehicleBrands.Queries.CountVehicleBrandsQueryRelated;

public sealed record CountVehicleBrandsQueryRequest(
    IFilteringRequestParameters<VehicleBrand> FilteringParameters) : ICountQueryRequest<VehicleBrand>;