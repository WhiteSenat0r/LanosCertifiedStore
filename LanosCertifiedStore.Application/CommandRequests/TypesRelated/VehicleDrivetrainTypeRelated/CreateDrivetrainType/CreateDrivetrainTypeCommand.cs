using Application.Shared.ResultRelated;
using MediatR;

namespace Application.CommandRequests.TypesRelated.VehicleDrivetrainTypeRelated.CreateDrivetrainType;

public sealed record CreateDrivetrainTypeCommand(string Name) : IRequest<Result<Unit>>;