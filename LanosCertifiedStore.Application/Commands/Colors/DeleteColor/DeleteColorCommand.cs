using Application.Shared.ResultRelated;
using MediatR;

namespace Application.Commands.Colors.DeleteColor;

public sealed record DeleteColorCommand(Guid Id) : IRequest<Result<Unit>>;