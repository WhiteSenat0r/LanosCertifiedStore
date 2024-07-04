using Application.Shared.ResultRelated;
using MediatR;

namespace Application.CommandRequests.TypesRelated.VehicleEngineTypeRelated.UpdateEngineType;

public sealed record UpdateEngineTypeCommand(Guid Id, string UpdatedName) : IRequest<Result<Unit>>;