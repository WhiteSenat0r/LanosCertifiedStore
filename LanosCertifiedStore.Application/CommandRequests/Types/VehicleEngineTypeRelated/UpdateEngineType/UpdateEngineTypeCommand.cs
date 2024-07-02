using Application.Shared.ResultRelated;
using MediatR;

namespace Application.CommandRequests.Types.VehicleEngineTypeRelated.UpdateEngineType;

public sealed record UpdateEngineTypeCommand(Guid Id, string UpdatedName) : IRequest<Result<Unit>>;