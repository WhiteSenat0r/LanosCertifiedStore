using Application.Shared.ResultRelated;
using MediatR;

namespace Application.Commands.Types.VehicleDrivetrainTypeRelated.CreateDrivetrainType;

public sealed record CreateDrivetrainTypeCommand(string Name) : IRequest<Result<Unit>>;