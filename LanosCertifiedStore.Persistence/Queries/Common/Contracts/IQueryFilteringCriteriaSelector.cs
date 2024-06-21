using System.Linq.Expressions;
using Application.Contracts.RepositoryRelated.Common;
using Domain.Contracts.Common;

namespace Persistence.Queries.Common.Contracts;

internal interface IQueryFilteringCriteriaSelector<TModel, TEntity>
    where TEntity : class, IIdentifiable<Guid>
    where TModel : class, IIdentifiable<Guid>
{
    Expression<Func<TEntity, bool>> GetCriteria(IFilteringRequestParameters<TModel>? filteringRequestParameters = null);
}