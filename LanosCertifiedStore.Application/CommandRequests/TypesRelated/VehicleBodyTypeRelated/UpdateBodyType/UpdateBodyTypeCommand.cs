using Application.Shared.ResultRelated;
using MediatR;

namespace Application.CommandRequests.TypesRelated.VehicleBodyTypeRelated.UpdateBodyType;

public sealed record UpdateBodyTypeCommand(Guid Id, string UpdatedName) : IRequest<Result<Unit>>;