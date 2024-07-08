using Application.Shared.ResultRelated;
using MediatR;

namespace Application.VehicleModels.Commands.DeleteModel;

public sealed record DeleteModelCommand(Guid Id) : IRequest<Result<Unit>>;