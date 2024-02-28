using Domain.Shared;
using MediatR;

namespace Application.Commands.Models.CreateModel;

public sealed record CreateModelCommand(Guid BrandId, string Name, IEnumerable<Guid> AvailableTypesIds)
    : IRequest<Result<Unit>>;