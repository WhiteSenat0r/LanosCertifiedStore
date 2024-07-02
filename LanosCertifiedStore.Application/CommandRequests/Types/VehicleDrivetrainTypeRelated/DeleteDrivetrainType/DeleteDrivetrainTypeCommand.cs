using Application.Shared.ResultRelated;
using MediatR;

namespace Application.CommandRequests.Types.VehicleDrivetrainTypeRelated.DeleteDrivetrainType;

public sealed record DeleteDrivetrainTypeCommand(Guid Id) : IRequest<Result<Unit>>;