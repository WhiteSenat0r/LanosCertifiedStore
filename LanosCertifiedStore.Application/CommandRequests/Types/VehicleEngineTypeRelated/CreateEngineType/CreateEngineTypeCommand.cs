using Application.Shared.ResultRelated;
using MediatR;

namespace Application.CommandRequests.Types.VehicleEngineTypeRelated.CreateEngineType;

public sealed record CreateEngineTypeCommand(string Name) : IRequest<Result<Unit>>;