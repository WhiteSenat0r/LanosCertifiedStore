using Application.Shared.ResultRelated;
using Domain.Contracts.Common;

namespace Application.Contracts.RequestRelated.QueryRelated;

public interface ISingleQueryRequest<TEntity, TRequestResult> : 
    IQueryRequest<TEntity, Result<TRequestResult>>
    where TEntity : class, IIdentifiable<Guid>
    where TRequestResult : class
{
    Guid ItemId { get; }
}