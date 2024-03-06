using Domain.Contracts.Common;
using Domain.Contracts.RepositoryRelated.Common;

namespace Application.Queries.Common.CountItemsQueryRelated;

public abstract record CountItemsQueryBase<TEntity>(
    IFilteringRequestParameters<TEntity>? RequestParameters)
    where TEntity : class, IIdentifiable<Guid>;