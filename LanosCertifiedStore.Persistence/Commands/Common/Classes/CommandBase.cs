using Application.Contracts.RequestRelated;
using Application.Shared.ResultRelated;
using Domain.Contracts.Common;
using Persistence.Commands.Common.Contracts;

namespace Persistence.Commands.Common.Classes;

internal abstract class CommandBase<TModel, TRequest, TRequestResult> : 
    ICommand<TModel, TRequest, TRequestResult>
    where TModel : class, IIdentifiable<Guid> 
    where TRequest : ICommandRequest<TModel, TRequestResult>
    where TRequestResult : notnull
{
    public abstract Task<Result<TModel>> Execute(TRequest commandRequest, CancellationToken cancellationToken);
}