using Application.Shared.RequestRelated.QueryRelated;
using Application.VehicleModels.Dtos;

namespace Application.VehicleModels.Queries.SingleVehicleModelQueryRelated;

public sealed record SingleVehicleModelQueryRequest(
    Guid ItemId) : ISingleQueryRequest<SingleVehicleModelDto>;