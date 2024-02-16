using Application.Core;
using Application.Dtos.TypeDtos;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Types.UpdateType;

public sealed record UpdateTypeCommand(UpdateTypeDto UpdateTypeDto) : IRequest<Result<Unit>>;