using Application.Shared.ResultRelated;
using MediatR;

namespace Application.Commands.Types.VehicleTransmissionTypeRelated.CreateTransmissionType;

public sealed record CreateTransmissionTypeCommand(string Name) : IRequest<Result<Unit>>;