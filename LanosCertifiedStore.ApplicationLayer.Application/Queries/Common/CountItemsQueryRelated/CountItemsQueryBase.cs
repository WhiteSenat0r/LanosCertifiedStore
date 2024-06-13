using Application.Contracts.RepositoryRelated.Common;
using Domain.Contracts.Common;

namespace Application.Queries.Common.CountItemsQueryRelated;

public abstract record CountItemsQueryBase<TEntity>(
    IFilteringRequestParameters<TEntity>? RequestParameters)
    where TEntity : class, IIdentifiable<Guid>;