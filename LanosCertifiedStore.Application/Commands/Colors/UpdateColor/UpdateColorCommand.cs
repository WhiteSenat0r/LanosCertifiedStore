using Application.Shared.ResultRelated;
using MediatR;

namespace Application.Commands.Colors.UpdateColor;

public sealed record UpdateColorCommand(Guid Id, string UpdatedName, string UpdatedHexValue) : IRequest<Result<Unit>>;