using Application.Constants;
using Application.Contracts.RequestRelated;
using Application.Contracts.ServicesRelated.RequestRelated;
using Application.Shared.ResultRelated;
using Domain.Contracts.Common;
using Persistence.Factories.CommandRelated.Common.Contracts;

namespace Persistence.Services;

internal sealed class CommandService(ICommandFactory commandFactory) : ICommandService
{
    public async Task<Result<TModel>> GetResult<TModel, TRequest, TRequestResult>(
        TRequest commandRequest,
        CancellationToken cancellationToken) 
        where TModel : class, IIdentifiable<Guid>
        where TRequest : ICommandRequest<TModel, TRequestResult>
        where TRequestResult : notnull
    {
        try
        {
            var command = commandFactory.GetCommand<TModel, TRequest, TRequestResult>(commandRequest);
            var result = await command.Execute(commandRequest, cancellationToken);

            return result;
        }
        catch (Exception)
        {
            return Result<TModel>.Failure(new Error(
                CommandServiceConstants.NonProcessableCommandRequestCode,
                CommandServiceConstants.NonProcessableCommandMessage));
        }
    }
}