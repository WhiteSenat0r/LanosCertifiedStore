using Domain.Shared;
using MediatR;

namespace Application.Commands.Types.VehicleTypeRelated.UpdateType;

public sealed record UpdateTypeCommand(Guid Id, string UpdatedName) : IRequest<Result<Unit>>;