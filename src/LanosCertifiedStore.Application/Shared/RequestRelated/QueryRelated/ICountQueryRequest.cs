using Application.Shared.DtosRelated;
using Application.Shared.ResultRelated;
using Domain.Contracts.Common;

namespace Application.Shared.RequestRelated.QueryRelated;

public interface ICountQueryRequest<TEntity> : 
    IQueryRequest<TEntity, Result<ItemsCountDto>>
    where TEntity : class, IIdentifiable<Guid>;