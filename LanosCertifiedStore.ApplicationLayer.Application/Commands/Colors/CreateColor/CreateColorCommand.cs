using Application.Dtos.ColorDtos;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Colors.CreateColor;

public sealed record CreateColorCommand(CreateColorDto CreateColorDto) : IRequest<Result<Unit>>;