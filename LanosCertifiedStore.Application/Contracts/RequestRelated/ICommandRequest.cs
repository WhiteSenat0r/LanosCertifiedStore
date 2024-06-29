using Application.Shared.ResultRelated;
using Domain.Contracts.Common;
using MediatR;

namespace Application.Contracts.RequestRelated;

public interface ICommandRequest<TModel, TResult> : IRequest<Result<TResult>>
    where TModel : class, IIdentifiable<Guid>
    where TResult : notnull;