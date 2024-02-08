using Application.Core;
using Application.Dtos.TypeDtos;
using MediatR;

namespace Application.Commands.Types.UpdateType;

public sealed record UpdateTypeCommand(UpdateTypeDto UpdateTypeDto) : IRequest<Result<Unit>>;