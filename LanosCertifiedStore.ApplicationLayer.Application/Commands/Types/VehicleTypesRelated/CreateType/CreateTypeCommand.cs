using Domain.Shared;
using MediatR;

namespace Application.Commands.Types.VehicleTypesRelated.CreateType;

public sealed record CreateTypeCommand(string Name) : IRequest<Result<Unit>>;