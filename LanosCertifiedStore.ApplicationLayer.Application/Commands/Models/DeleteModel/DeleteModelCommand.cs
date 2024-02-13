using Application.Core;
using MediatR;

namespace Application.Commands.Models.DeleteModel;

public sealed record DeleteModelCommand(string Name) : IRequest<Result<Unit>>;