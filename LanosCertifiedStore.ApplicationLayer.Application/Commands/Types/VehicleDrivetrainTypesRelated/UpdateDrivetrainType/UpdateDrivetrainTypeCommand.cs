using Domain.Shared;
using MediatR;

namespace Application.Commands.Types.VehicleDrivetrainTypesRelated.UpdateDrivetrainType;

public sealed record UpdateDrivetrainTypeCommand(Guid Id, string UpdatedName) : IRequest<Result<Unit>>;