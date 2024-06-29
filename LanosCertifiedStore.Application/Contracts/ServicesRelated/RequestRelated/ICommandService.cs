using Application.Contracts.RequestRelated;
using Application.Shared.ResultRelated;
using Domain.Contracts.Common;

namespace Application.Contracts.ServicesRelated.RequestRelated;

public interface ICommandService
{
    Task<Result<TModel>> GetResult<TModel, TRequest, TRequestResult>(
        TRequest commandRequest,
        CancellationToken cancellationToken)
        where TModel : class, IIdentifiable<Guid>
        where TRequest : ICommandRequest<TModel, TRequestResult>
        where TRequestResult : notnull;
}