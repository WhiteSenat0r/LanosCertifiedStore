using Domain.Shared;
using MediatR;

namespace Application.Commands.Types.VehicleEngineTypeRelated.DeleteEngineType;

public sealed record DeleteEngineTypeCommand(Guid Id) : IRequest<Result<Unit>>;