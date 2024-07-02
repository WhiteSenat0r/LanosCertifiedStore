using Application.Shared.ResultRelated;
using MediatR;

namespace Application.CommandRequests.Types.VehicleBodyTypeRelated.DeleteBodyType;

public sealed record DeleteBodyTypeCommand(Guid Id) : IRequest<Result<Unit>>;