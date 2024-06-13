using Application.Shared;
using MediatR;

namespace Application.Commands.Types.VehicleEngineTypeRelated.CreateEngineType;

public sealed record CreateEngineTypeCommand(string Name) : IRequest<Result<Unit>>;