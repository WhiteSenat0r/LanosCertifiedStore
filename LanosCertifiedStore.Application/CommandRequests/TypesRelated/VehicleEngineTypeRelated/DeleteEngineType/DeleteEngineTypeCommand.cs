using Application.Shared.ResultRelated;
using MediatR;

namespace Application.CommandRequests.TypesRelated.VehicleEngineTypeRelated.DeleteEngineType;

public sealed record DeleteEngineTypeCommand(Guid Id) : IRequest<Result<Unit>>;