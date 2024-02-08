using Application.Core;
using MediatR;

namespace Application.Commands.Models.CreateModel;

public sealed record CreateModelCommand(Guid BrandId, string Name) : IRequest<Result<Unit>>;