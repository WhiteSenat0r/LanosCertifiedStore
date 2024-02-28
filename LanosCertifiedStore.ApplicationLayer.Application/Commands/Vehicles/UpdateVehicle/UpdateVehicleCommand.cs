using Application.Commands.Vehicles.Common;
using Application.Dtos.VehicleDtos;
using Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Commands.Vehicles.UpdateVehicle;

public record UpdateVehicleCommand(
    Guid ModelId,
    Guid TypeId,
    Guid ColorId,
    string Description,
    double Displacement,
    decimal Price) : IActionVehicleCommandBase;