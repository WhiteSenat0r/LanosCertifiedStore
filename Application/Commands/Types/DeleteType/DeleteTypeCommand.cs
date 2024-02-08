using Application.Core;
using MediatR;

namespace Application.Commands.Types.DeleteType;

public sealed record DeleteTypeCommand(string Name) : IRequest<Result<Unit>>;