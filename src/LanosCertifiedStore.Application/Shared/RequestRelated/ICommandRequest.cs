using LanosCertifiedStore.Application.Shared.ResultRelated;
using MediatR;

namespace LanosCertifiedStore.Application.Shared.RequestRelated;

public interface ICommandRequest<TResult> : IRequest<Result<TResult>> where TResult : notnull;