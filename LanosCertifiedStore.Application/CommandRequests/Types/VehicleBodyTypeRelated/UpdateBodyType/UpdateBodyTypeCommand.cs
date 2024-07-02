using Application.Shared.ResultRelated;
using MediatR;

namespace Application.CommandRequests.Types.VehicleBodyTypeRelated.UpdateBodyType;

public sealed record UpdateBodyTypeCommand(Guid Id, string UpdatedName) : IRequest<Result<Unit>>;