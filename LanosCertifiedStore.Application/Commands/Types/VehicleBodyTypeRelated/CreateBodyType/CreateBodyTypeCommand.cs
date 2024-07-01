using Application.Shared.ResultRelated;
using MediatR;

namespace Application.Commands.Types.VehicleBodyTypeRelated.CreateBodyType;

public sealed record CreateBodyTypeCommand(string Name) : IRequest<Result<Unit>>;