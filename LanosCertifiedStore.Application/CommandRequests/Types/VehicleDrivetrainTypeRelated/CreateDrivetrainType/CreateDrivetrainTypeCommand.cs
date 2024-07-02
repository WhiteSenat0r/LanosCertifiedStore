using Application.Shared.ResultRelated;
using MediatR;

namespace Application.CommandRequests.Types.VehicleDrivetrainTypeRelated.CreateDrivetrainType;

public sealed record CreateDrivetrainTypeCommand(string Name) : IRequest<Result<Unit>>;