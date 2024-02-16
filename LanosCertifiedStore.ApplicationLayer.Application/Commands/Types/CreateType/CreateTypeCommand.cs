using Application.Core;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Types.CreateType;

public sealed record CreateTypeCommand(string Name) : IRequest<Result<Unit>>;