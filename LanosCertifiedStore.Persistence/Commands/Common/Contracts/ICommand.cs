using Application.Contracts.RequestRelated;
using Application.Shared.ResultRelated;
using Domain.Contracts.Common;

namespace Persistence.Commands.Common.Contracts;

internal interface ICommand<TModel, TRequest, TRequestResult>
    where TModel : class, IIdentifiable<Guid>
    where TRequest : ICommandRequest<TModel, TRequestResult>
    where TRequestResult : notnull
{
    Task<Result<TModel>> Execute(TRequest commandRequest, CancellationToken cancellationToken);
}