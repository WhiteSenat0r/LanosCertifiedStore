using Application.Dtos.VehicleDtos;
using Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Commands.Vehicles.CreateVehicle;

public record CreateVehicleCommand(
    ActionVehicleDto ActionVehicleDto,
    ICollection<IFormFile> Images,
    string MainImageName) : IRequest<Result<Unit>>;