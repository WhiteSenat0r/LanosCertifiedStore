using System.Linq.Expressions;
using Domain.Contracts.Common;

namespace Persistence.Queries.Common.Contracts;

internal interface IQueryFilteringCriteriaSelector<TEntity>
    where TEntity : class, IIdentifiable<Guid>
{
    Expression<Func<TEntity, bool>> GetCriteria();
}