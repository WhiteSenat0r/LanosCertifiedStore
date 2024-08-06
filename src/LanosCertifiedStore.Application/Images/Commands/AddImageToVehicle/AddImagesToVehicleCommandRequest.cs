using LanosCertifiedStore.Application.Shared.RequestRelated;
using Microsoft.AspNetCore.Http;

namespace LanosCertifiedStore.Application.Images.Commands.AddImageToVehicle;

public sealed record AddImagesToVehicleCommandRequest(
    Guid VehicleId,
    List<IFormFile> Images) : ICommandRequest;