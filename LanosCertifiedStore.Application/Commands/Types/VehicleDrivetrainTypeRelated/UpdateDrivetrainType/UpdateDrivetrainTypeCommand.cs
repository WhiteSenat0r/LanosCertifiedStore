using Application.Shared.ResultRelated;
using MediatR;

namespace Application.Commands.Types.VehicleDrivetrainTypeRelated.UpdateDrivetrainType;

public sealed record UpdateDrivetrainTypeCommand(Guid Id, string UpdatedName) : IRequest<Result<Unit>>;