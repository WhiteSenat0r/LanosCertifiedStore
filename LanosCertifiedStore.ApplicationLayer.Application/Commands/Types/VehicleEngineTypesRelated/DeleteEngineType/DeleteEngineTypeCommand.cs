using Domain.Shared;
using MediatR;

namespace Application.Commands.Types.VehicleEngineTypesRelated.DeleteEngineType;

public sealed record DeleteEngineTypeCommand(Guid Id) : IRequest<Result<Unit>>;