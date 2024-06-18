using Application.Shared;
using MediatR;

namespace Application.Commands.Types.VehicleBodyTypeRelated.UpdateBodyType;

public sealed record UpdateBodyTypeCommand(Guid Id, string UpdatedName) : IRequest<Result<Unit>>;