using System.Linq.Expressions;
using Application.Contracts.RepositoryRelated.Common;
using Domain.Contracts.Common;

namespace Persistence.Queries.Common.Contracts;

public interface IQueryFilteringCriteriaSelector<TEntity>
    where TEntity : class, IIdentifiable<Guid>
{
    Expression<Func<TEntity, bool>> GetCriteria(
        IFilteringRequestParameters<TEntity>? filteringRequestParameters = null);
}