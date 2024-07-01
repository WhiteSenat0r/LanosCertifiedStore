using Application.Shared.ResultRelated;
using MediatR;

namespace Application.Commands.Types.VehicleEngineTypeRelated.CreateEngineType;

public sealed record CreateEngineTypeCommand(string Name) : IRequest<Result<Unit>>;