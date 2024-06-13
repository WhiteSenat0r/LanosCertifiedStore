using Application.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Commands.Vehicles.AddImageToVehicle;

public sealed record AddImageToVehicleCommand(
    Guid VehicleId,
    IFormFile Image) : IRequest<Result<Unit>>;