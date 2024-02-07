using Application.Core;
using MediatR;

namespace Application.Commands.Models.CreateModel;

public sealed record CreateModelCommand(string Name) : IRequest<Result<Unit>>;