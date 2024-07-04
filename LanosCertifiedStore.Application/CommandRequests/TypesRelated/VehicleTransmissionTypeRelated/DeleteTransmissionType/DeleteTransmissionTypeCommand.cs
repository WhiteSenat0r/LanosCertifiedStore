using Application.Shared.ResultRelated;
using MediatR;

namespace Application.CommandRequests.TypesRelated.VehicleTransmissionTypeRelated.DeleteTransmissionType;

public sealed record DeleteTransmissionTypeCommand(Guid Id) : IRequest<Result<Unit>>;