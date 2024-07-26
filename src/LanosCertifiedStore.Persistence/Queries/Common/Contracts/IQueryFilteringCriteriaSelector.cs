using System.Linq.Expressions;
using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Domain.Contracts.Common;

namespace LanosCertifiedStore.Persistence.Queries.Common.Contracts;

public interface IQueryFilteringCriteriaSelector<TEntity>
    where TEntity : class, IIdentifiable<Guid>
{
    Expression<Func<TEntity, bool>> GetCriteria(
        IFilteringRequestParameters<TEntity>? filteringRequestParameters = null);
}