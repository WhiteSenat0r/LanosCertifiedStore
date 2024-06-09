using Domain.Shared;
using MediatR;

namespace Application.Commands.Types.VehicleTransmissionTypeRelated.DeleteTransmissionType;

public sealed record DeleteTransmissionTypeCommand(Guid Id) : IRequest<Result<Unit>>;