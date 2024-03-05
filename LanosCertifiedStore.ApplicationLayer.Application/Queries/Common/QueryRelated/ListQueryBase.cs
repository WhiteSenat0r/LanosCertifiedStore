using Application.RequestParams.Common.Classes;
using Domain.Contracts.Common;

namespace Application.Queries.Common.QueryRelated;

public abstract record ListQueryBase<TEntity, TParamsType>(TParamsType RequestParameters)
    where TEntity : IIdentifiable<Guid>
    where TParamsType : BaseFilteringRequestParameters<TEntity>;