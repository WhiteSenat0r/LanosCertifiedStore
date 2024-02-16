using Domain.Shared;
using MediatR;

namespace Application.Commands.Colors.DeleteColor;

public sealed record DeleteColorCommand(Guid Id) : IRequest<Result<Unit>>;