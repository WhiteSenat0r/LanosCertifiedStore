using Application.Contracts.RequestRelated;
using Domain.Contracts.Common;
using Persistence.Commands.Common.Contracts;
using Persistence.Factories.CommandRelated.Common.Classes.Common.Classes.Constants;
using Persistence.Factories.CommandRelated.Common.Contracts;

namespace Persistence.Factories.CommandRelated.Common.Classes;

internal sealed class CommandFactory(IEnumerable<object> commands) : ICommandFactory
{
    public ICommand<TModel, TRequest, TRequestResult> GetCommand<TModel, TRequest, TRequestResult>(
        TRequest commandRequest)
        where TModel : class, IIdentifiable<Guid>
        where TRequest : ICommandRequest<TModel, TRequestResult>
        where TRequestResult : notnull
    {
        var command = GetCommand<TModel, TRequest, TRequestResult>(commands);

        return command;
    }
    
    private ICommand<TModel, TRequest, TRequestResult> GetCommand<TModel, TRequest, TRequestResult>(
        IEnumerable<object> commandObjects)
        where TModel : class, IIdentifiable<Guid>
        where TRequest : ICommandRequest<TModel, TRequestResult>
        where TRequestResult : notnull
    {
        foreach (var command in commandObjects)
        {
            var commandInterfaceType = command.GetType().GetInterfaces().First();

            if (commandInterfaceType.GenericTypeArguments[0] != typeof(TModel) ||
                commandInterfaceType.GenericTypeArguments[1] != typeof(TRequest) ||
                commandInterfaceType.GenericTypeArguments[2] != typeof(TRequestResult))
                continue;
            
            return (ICommand<TModel, TRequest, TRequestResult>)command;
        }

        throw new NullReferenceException(CommandFactoryConstants.NotFoundCommand);
    }
}