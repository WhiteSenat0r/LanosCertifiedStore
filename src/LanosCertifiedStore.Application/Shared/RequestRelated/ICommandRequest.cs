using Application.Shared.ResultRelated;
using MediatR;

namespace Application.Shared.RequestRelated;

public interface ICommandRequest<TResult> : IRequest<Result<TResult>> where TResult : notnull;