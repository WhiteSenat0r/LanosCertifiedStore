using Application.Dtos.Common;
using Application.Shared.ResultRelated;
using Domain.Contracts.Common;

namespace Application.Contracts.RequestRelated.QueryRelated;

public interface ICountQueryRequest<TEntity> : 
    IQueryRequest<TEntity, Result<ItemsCountDto>>
    where TEntity : class, IIdentifiable<Guid>;