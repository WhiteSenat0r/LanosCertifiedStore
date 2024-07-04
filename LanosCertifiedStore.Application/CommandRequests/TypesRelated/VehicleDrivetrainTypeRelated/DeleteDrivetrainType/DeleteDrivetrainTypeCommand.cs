using Application.Shared.ResultRelated;
using MediatR;

namespace Application.CommandRequests.TypesRelated.VehicleDrivetrainTypeRelated.DeleteDrivetrainType;

public sealed record DeleteDrivetrainTypeCommand(Guid Id) : IRequest<Result<Unit>>;