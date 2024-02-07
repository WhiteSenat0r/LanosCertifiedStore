using Application.Core;
using Application.Dtos.ModelDtos;
using MediatR;

namespace Application.Commands.Models.UpdateModel;

public sealed record UpdateModelCommand(UpdateModelDto UpdateModelDto) : IRequest<Result<Unit>>;