using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Domain.Contracts.Common;

namespace LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;

public interface ICollectionQueryRequest<TEntity, TRequestResult, TDto> :
    IQueryRequest<TEntity, Result<TRequestResult>>
    where TEntity : class, IIdentifiable<Guid>
    where TRequestResult : PaginationResult<TDto>
    where TDto : class;