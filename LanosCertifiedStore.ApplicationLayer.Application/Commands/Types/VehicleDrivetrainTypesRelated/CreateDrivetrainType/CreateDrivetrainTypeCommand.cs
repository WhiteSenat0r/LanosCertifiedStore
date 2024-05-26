using Domain.Shared;
using MediatR;

namespace Application.Commands.Types.VehicleDrivetrainTypesRelated.CreateDrivetrainType;

public sealed record CreateDrivetrainTypeCommand(string Name) : IRequest<Result<Unit>>;