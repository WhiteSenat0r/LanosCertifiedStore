using Application.Shared.ResultRelated;
using Domain.Contracts.Common;

namespace Application.Contracts.RequestRelated.QueryRelated;

public interface ICollectionQueryRequest<TEntity, TRequestResult, TDto> :
    IQueryRequest<TEntity, Result<TRequestResult>>
    where TEntity : class, IIdentifiable<Guid>
    where TRequestResult : PaginationResult<TDto>
    where TDto : class;