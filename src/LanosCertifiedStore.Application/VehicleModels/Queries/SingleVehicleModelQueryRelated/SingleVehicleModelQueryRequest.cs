using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Application.VehicleModels.Dtos;

namespace LanosCertifiedStore.Application.VehicleModels.Queries.SingleVehicleModelQueryRelated;

public sealed record SingleVehicleModelQueryRequest(
    Guid ItemId) : ISingleQueryRequest<SingleVehicleModelDto>;