using Application.Shared.ResultRelated;
using Domain.Contracts.Common;
using MediatR;

namespace Application.Contracts.RequestRelated;

public interface ICommandRequest<TEntity, TResult> : IRequest<Result<TResult>>
    where TEntity : class, IIdentifiable<Guid>
    where TResult : notnull;