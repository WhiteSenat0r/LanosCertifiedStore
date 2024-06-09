using Domain.Shared;
using MediatR;

namespace Application.Commands.Types.VehicleBodyTypeRelated.DeleteBodyType;

public sealed record DeleteBodyTypeCommand(Guid Id) : IRequest<Result<Unit>>;