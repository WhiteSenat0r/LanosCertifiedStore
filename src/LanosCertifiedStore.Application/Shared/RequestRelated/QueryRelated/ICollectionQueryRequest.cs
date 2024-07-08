using Application.Shared.ResultRelated;
using Domain.Contracts.Common;

namespace Application.Shared.RequestRelated.QueryRelated;

public interface ICollectionQueryRequest<TEntity, TRequestResult, TDto> :
    IQueryRequest<TEntity, Result<TRequestResult>>
    where TEntity : class, IIdentifiable<Guid>
    where TRequestResult : PaginationResult<TDto>
    where TDto : class;