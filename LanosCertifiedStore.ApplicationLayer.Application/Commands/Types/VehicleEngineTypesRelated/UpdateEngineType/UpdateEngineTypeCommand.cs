using Domain.Shared;
using MediatR;

namespace Application.Commands.Types.VehicleEngineTypesRelated.UpdateEngineType;

public sealed record UpdateEngineTypeCommand(Guid Id, string UpdatedName) : IRequest<Result<Unit>>;