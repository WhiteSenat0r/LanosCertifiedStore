using Application.Shared.RequestRelated.QueryRelated;
using Application.VehicleBrands.Dtos;

namespace Application.VehicleBrands.Queries.SingleVehicleBrandQueryRelated;

public sealed record SingleVehicleBrandQueryRequest(
    Guid ItemId) : ISingleQueryRequest<SingleVehicleBrandDto>;