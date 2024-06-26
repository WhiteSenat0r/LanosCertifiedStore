using Domain.Contracts.Common;

namespace Persistence.Queries.Common.Contracts;

internal interface ISingleQuery<TModel, TQueryResult> : IQuery<TModel, TQueryResult>
    where TModel : class, IIdentifiable<Guid>
    where TQueryResult : TModel;