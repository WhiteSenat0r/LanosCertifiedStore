using LanosCertifiedStore.Application.Shared.ResultRelated;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace LanosCertifiedStore.Application.Images.Commands.AddImageToVehicle;

public sealed record AddImageToVehicleCommand(
    Guid VehicleId,
    IFormFile Image) : IRequest<Result<Unit>>;