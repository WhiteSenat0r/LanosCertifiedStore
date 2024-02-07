using Application.Core;
using MediatR;

namespace Application.Commands.Colors.DeleteColor;

public sealed record DeleteColorCommand(string ColorName) : IRequest<Result<Unit>>;