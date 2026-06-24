using LanosCertifiedStore.Application.Shared.DtosRelated;
using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using MediatR;

namespace LanosCertifiedStore.Application.Vehicles.Queries.CountVehiclesQueryRelated;

public sealed record CountVehiclesQueryRequest(
    IVehicleFilteringRequestParameters FilteringParameters) :
    ICountQueryRequest<Vehicle>,
    IRequest<Result<ItemsCountDto>>;