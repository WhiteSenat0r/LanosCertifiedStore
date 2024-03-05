using Domain.Contracts.Common;

namespace Application.Queries.Common.DetailsQueryRelated;

public abstract record DetailsQueryBase<TEntity>(Guid Id) where TEntity : IIdentifiable<Guid>;