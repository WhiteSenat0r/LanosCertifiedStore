using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Application.Vehicles.Dtos;

namespace LanosCertifiedStore.Application.Vehicles.Queries.SingleVehicleQueryRequestRelated;

public sealed record SingleVehicleQueryRequest(Guid ItemId) : ISingleQueryRequest<SingleVehicleDto>;