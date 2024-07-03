using Application.Contracts.RequestRelated.QueryRelated;
using Application.Dtos.BrandDtos;

namespace Application.QueryRequests.VehicleBrandsRelated.SingleVehicleBrandQueryRelated;

public sealed record SingleVehicleBrandQueryRequest(
    Guid ItemId) : ISingleQueryRequest<SingleVehicleBrandDto>;