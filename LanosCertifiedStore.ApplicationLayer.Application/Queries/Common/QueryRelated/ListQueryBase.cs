using Domain.Contracts.Common;
using Domain.Contracts.RepositoryRelated.Common;

namespace Application.Queries.Common.QueryRelated;

public abstract record ListQueryBase<TEntity, TParamsType>(TParamsType RequestParameters)
    where TEntity : IIdentifiable<Guid>
    where TParamsType : IFilteringRequestParameters<TEntity>;