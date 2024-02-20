using Application.Commands.Vehicles.Common;
using Application.Dtos.VehicleDtos;
using Microsoft.AspNetCore.Http;

namespace Application.Commands.Vehicles.CreateVehicle;

public record CreateVehicleCommand(
    CreateVehicleDto CreateVehicleDto,
    ICollection<IFormFile> Images,
    string MainImageName) : IActionVehicleCommandBase;