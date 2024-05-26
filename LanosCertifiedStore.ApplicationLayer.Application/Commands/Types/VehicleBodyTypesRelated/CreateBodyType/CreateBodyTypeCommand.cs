using Domain.Shared;
using MediatR;

namespace Application.Commands.Types.VehicleBodyTypesRelated.CreateBodyType;

public sealed record CreateBodyTypeCommand(string Name) : IRequest<Result<Unit>>;