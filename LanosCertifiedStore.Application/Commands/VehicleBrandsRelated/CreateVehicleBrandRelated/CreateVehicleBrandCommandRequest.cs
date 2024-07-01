using Application.Contracts.RequestRelated;
using Application.Dtos.BrandDtos;
using Domain.Entities.VehicleRelated;

namespace Application.Commands.VehicleBrandsRelated.CreateVehicleBrandRelated;

public sealed record CreateVehicleBrandCommandRequest(
    string Name) : ICommandRequest<VehicleBrand, VehicleBrandDto>;