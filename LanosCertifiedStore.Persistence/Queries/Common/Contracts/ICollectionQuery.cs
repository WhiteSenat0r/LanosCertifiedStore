using Domain.Contracts.Common;

namespace Persistence.Queries.Common.Contracts;

internal interface ICollectionQuery<TModel, TResult> : IQuery<TModel, TResult>
    where TModel : class, IIdentifiable<Guid>
    where TResult : IReadOnlyCollection<TModel>;