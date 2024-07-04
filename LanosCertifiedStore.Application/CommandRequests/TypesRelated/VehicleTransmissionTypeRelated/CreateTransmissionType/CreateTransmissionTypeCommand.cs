using Application.Shared.ResultRelated;
using MediatR;

namespace Application.CommandRequests.TypesRelated.VehicleTransmissionTypeRelated.CreateTransmissionType;

public sealed record CreateTransmissionTypeCommand(string Name) : IRequest<Result<Unit>>;