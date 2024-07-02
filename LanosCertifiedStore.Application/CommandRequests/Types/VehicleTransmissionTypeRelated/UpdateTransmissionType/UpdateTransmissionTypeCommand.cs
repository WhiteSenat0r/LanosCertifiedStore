using Application.Shared.ResultRelated;
using MediatR;

namespace Application.CommandRequests.Types.VehicleTransmissionTypeRelated.UpdateTransmissionType;

public sealed record UpdateTransmissionTypeCommand(Guid Id, string UpdatedName) : IRequest<Result<Unit>>;