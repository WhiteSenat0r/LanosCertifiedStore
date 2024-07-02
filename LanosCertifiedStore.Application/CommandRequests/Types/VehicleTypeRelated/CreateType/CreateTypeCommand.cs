using Application.Shared.ResultRelated;
using MediatR;

namespace Application.CommandRequests.Types.VehicleTypeRelated.CreateType;

public sealed record CreateTypeCommand(string Name) : IRequest<Result<Unit>>;