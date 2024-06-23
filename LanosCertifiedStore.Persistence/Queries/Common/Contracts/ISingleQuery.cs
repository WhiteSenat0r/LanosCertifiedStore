using Application.Shared;
using Domain.Contracts.Common;

namespace Persistence.Queries.Common.Contracts;

internal interface ISingleQuery<TModel, TQueryResult, TRequestResult, TDto> : IQuery<TModel, TQueryResult>
    where TModel : class, IIdentifiable<Guid>
    where TQueryResult : TModel
    where TRequestResult : Result<TDto>;