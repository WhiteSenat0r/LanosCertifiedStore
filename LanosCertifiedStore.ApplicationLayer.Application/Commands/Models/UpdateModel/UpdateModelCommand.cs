using Application.Shared;
using MediatR;

namespace Application.Commands.Models.UpdateModel;

public sealed record UpdateModelCommand(
    Guid Id,
    Guid BrandId,
    Guid TypeId,
    string Name,
    IEnumerable<Guid> AvailableEngineTypeIds,
    IEnumerable<Guid> AvailableTransmissionTypeIds,
    IEnumerable<Guid> AvailableDrivetrainTypeIds,
    IEnumerable<Guid> AvailableBodyTypeIds,
    int MinimalProductionYear,
    int? MaximumProductionYear = null) : IRequest<Result<Unit>>;