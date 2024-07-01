using Application.Shared.ResultRelated;
using MediatR;

namespace Application.Commands.Types.VehicleTransmissionTypeRelated.DeleteTransmissionType;

public sealed record DeleteTransmissionTypeCommand(Guid Id) : IRequest<Result<Unit>>;