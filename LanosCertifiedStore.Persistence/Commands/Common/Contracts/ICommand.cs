using Application.Contracts.RequestRelated;
using Application.Shared.ResultRelated;
using Domain.Contracts.Common;

namespace Persistence.Commands.Common.Contracts;

internal interface ICommand<TEntity, TRequest, TRequestResult>
    where TEntity : class, IIdentifiable<Guid>
    where TRequest : ICommandRequest<TEntity, TRequestResult>
    where TRequestResult : notnull
{
    Task<Result<TEntity>> Execute(TRequest commandRequest, CancellationToken cancellationToken);
}