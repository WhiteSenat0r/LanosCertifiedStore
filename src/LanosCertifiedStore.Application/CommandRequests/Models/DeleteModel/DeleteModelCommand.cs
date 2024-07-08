using Application.Shared.ResultRelated;
using MediatR;

namespace Application.CommandRequests.Models.DeleteModel;

public sealed record DeleteModelCommand(Guid Id) : IRequest<Result<Unit>>;