using Application.Shared;
using MediatR;

namespace Application.Commands.Colors.CreateColor;

public sealed record CreateColorCommand(string ColorName, string HexValue) : IRequest<Result<Unit>>;