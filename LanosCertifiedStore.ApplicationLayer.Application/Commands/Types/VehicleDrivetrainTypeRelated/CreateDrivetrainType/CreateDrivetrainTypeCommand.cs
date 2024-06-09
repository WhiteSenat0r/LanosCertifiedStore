using Domain.Shared;
using MediatR;

namespace Application.Commands.Types.VehicleDrivetrainTypeRelated.CreateDrivetrainType;

public sealed record CreateDrivetrainTypeCommand(string Name) : IRequest<Result<Unit>>;