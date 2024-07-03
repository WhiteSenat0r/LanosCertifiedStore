using Application.Shared.ResultRelated;
using MediatR;

namespace Application.Contracts.RequestRelated;

public interface ICommandRequest<TResult> : IRequest<Result<TResult>> where TResult : notnull;