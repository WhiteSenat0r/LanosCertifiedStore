using Application.Shared;
using MediatR;

namespace Application.Commands.Types.VehicleEngineTypeRelated.UpdateEngineType;

public sealed record UpdateEngineTypeCommand(Guid Id, string UpdatedName) : IRequest<Result<Unit>>;