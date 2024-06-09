using Domain.Shared;
using MediatR;

namespace Application.Commands.Types.VehicleDrivetrainTypeRelated.DeleteDrivetrainType;

public sealed record DeleteDrivetrainTypeCommand(Guid Id) : IRequest<Result<Unit>>;