using LanosCertifiedStore.Application.Shared.ResultRelated;
using MediatR;

namespace LanosCertifiedStore.Application.Shared.RequestRelated;

public interface ICommandRequest<TResult> : ICommandRequestBase, IRequest<Result<TResult>> where TResult : notnull;

public interface ICommandRequest : ICommandRequestBase, IRequest<Result>;

public interface ICommandRequestBase;