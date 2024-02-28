using Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Commands.Vehicles.AddImagesToVehicle;

public sealed record AddImagesToVehicleCommand(
    Guid VehicleId,
    ICollection<IFormFile> Images,
    string MainImageName) : IRequest<Result<Unit>>;