using Application.Shared.ResultRelated;
using MediatR;

namespace Application.CommandRequests.TypesRelated.VehicleEngineTypeRelated.CreateEngineType;

public sealed record CreateEngineTypeCommand(string Name) : IRequest<Result<Unit>>;