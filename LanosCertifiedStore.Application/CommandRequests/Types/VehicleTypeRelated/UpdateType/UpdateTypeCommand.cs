using Application.Shared.ResultRelated;
using MediatR;

namespace Application.CommandRequests.Types.VehicleTypeRelated.UpdateType;

public sealed record UpdateTypeCommand(Guid Id, string UpdatedName) : IRequest<Result<Unit>>;