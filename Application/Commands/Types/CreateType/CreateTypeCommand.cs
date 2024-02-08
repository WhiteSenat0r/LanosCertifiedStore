using Application.Core;
using MediatR;

namespace Application.Commands.Types.CreateType;

public sealed record CreateTypeCommand(string Name) : IRequest<Result<Unit>>;