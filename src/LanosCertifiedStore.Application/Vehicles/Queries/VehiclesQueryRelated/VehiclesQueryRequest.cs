using LanosCertifiedStore.Application.Shared.RequestParamsRelated.RequestBases;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;

namespace LanosCertifiedStore.Application.Vehicles.Queries.VehiclesQueryRelated;

public sealed record VehiclesQueryRequest(
    IVehicleFilteringRequestParameters RequestParameters, bool IsTracked = false) :
    CollectionQueryRequestBase<Vehicle, PaginationResult<VehicleDto>>(RequestParameters, IsTracked);