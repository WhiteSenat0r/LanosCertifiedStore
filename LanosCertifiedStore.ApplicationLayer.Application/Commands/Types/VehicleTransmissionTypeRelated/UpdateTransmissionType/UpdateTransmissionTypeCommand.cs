using Domain.Shared;
using MediatR;

namespace Application.Commands.Types.VehicleTransmissionTypeRelated.UpdateTransmissionType;

public sealed record UpdateTransmissionTypeCommand(Guid Id, string UpdatedName) : IRequest<Result<Unit>>;