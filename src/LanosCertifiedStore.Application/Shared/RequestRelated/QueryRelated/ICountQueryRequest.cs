using LanosCertifiedStore.Application.Shared.DtosRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Domain.Contracts.Common;

namespace LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;

public interface ICountQueryRequest<TEntity> : 
    IQueryRequest<TEntity, Result<ItemsCountDto>>
    where TEntity : class, IIdentifiable<Guid>;