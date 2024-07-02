using Application.Shared.ResultRelated;
using MediatR;

namespace Application.CommandRequests.Models.UpdateModel;

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