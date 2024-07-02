using Application.Contracts.RequestRelated;
using Application.Shared.ResultRelated;
using Domain.Contracts.Common;
using Persistence.Commands.Common.Contracts;

namespace Persistence.Commands.Common.Classes;

internal abstract class CommandBase<TEntity, TRequest, TRequestResult> : 
    ICommand<TEntity, TRequest, TRequestResult>
    where TEntity : class, IIdentifiable<Guid> 
    where TRequest : ICommandRequest<TEntity, TRequestResult>
    where TRequestResult : notnull
{
    public abstract Task<Result<TEntity>> Execute(TRequest commandRequest, CancellationToken cancellationToken);
}