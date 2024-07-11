using Application.Shared.ResultRelated;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Images.Commands.AddImageToVehicle;

public sealed record AddImageToVehicleCommand(
    Guid VehicleId,
    IFormFile Image) : IRequest<Result<Unit>>;