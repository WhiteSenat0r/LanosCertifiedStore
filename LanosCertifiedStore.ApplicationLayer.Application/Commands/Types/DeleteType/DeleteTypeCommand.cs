using Application.Core;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Types.DeleteType;

public sealed record DeleteTypeCommand(Guid Id) : IRequest<Result<Unit>>;