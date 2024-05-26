using Domain.Shared;
using MediatR;

namespace Application.Commands.Types.VehicleEngineTypesRelated.CreateEngineType;

public sealed record CreateEngineTypeCommand(string Name) : IRequest<Result<Unit>>;