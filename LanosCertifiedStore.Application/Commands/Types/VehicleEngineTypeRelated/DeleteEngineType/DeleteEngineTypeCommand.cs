using Application.Shared.ResultRelated;
using MediatR;

namespace Application.Commands.Types.VehicleEngineTypeRelated.DeleteEngineType;

public sealed record DeleteEngineTypeCommand(Guid Id) : IRequest<Result<Unit>>;