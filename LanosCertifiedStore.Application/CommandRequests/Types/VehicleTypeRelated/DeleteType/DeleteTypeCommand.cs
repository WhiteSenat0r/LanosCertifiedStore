using Application.Shared.ResultRelated;
using MediatR;

namespace Application.CommandRequests.Types.VehicleTypeRelated.DeleteType;

public sealed record DeleteTypeCommand(Guid Id) : IRequest<Result<Unit>>;