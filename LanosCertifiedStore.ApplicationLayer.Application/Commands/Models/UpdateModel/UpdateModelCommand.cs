using Domain.Shared;
using MediatR;

namespace Application.Commands.Models.UpdateModel;

public sealed record UpdateModelCommand(
    Guid Id,
    string UpdatedName,
    Guid BrandId,
    IEnumerable<Guid> AvailableTypesIds)
    : IRequest<Result<Unit>>;