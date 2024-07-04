using Application.Shared.ResultRelated;
using MediatR;

namespace Application.CommandRequests.TypesRelated.VehicleDrivetrainTypeRelated.UpdateDrivetrainType;

public sealed record UpdateDrivetrainTypeCommand(Guid Id, string UpdatedName) : IRequest<Result<Unit>>;