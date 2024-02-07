using Application.Core;
using MediatR;

namespace Application.Commands.Colors.CreateColor;

public sealed record CreateColorCommand(string ColorName) : IRequest<Result<Unit>>;