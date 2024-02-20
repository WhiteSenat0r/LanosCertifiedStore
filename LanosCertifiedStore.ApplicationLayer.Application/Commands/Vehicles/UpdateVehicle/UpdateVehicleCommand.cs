using Application.Commands.Vehicles.Common;
using Application.Dtos.VehicleDtos;
using Microsoft.AspNetCore.Http;

namespace Application.Commands.Vehicles.UpdateVehicle;

public record UpdateVehicleCommand(
    UpdateVehicleDto UpdateVehicleDto,
    ICollection<IFormFile>? Images,
    string? MainImageName,
    Guid? MainImageId) : IActionVehicleCommandBase;