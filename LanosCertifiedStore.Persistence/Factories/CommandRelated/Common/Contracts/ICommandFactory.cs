using Application.Contracts.RequestRelated;
using Domain.Contracts.Common;
using Persistence.Commands.Common.Contracts;

namespace Persistence.Factories.CommandRelated.Common.Contracts;

internal interface ICommandFactory
{
    ICommand<TModel, TRequest, TRequestResult> GetCommand<TModel, TRequest, TRequestResult>(
        TRequest commandRequest)
        where TModel : class, IIdentifiable<Guid>
        where TRequest : ICommandRequest<TModel, TRequestResult>
        where TRequestResult : notnull;
}