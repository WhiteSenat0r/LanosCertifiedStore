using System.Linq.Expressions;
using Domain.Contracts.Common;
using Domain.Contracts.RepositoryRelated;

namespace Persistence.QueryEvaluation.Common;

internal abstract class BaseFilteringCriteria<TEntity, TDataModel> 
  where TEntity : IEntity<Guid>
  where TDataModel : class, IEntity<Guid>
{
    internal abstract Expression<Func<TDataModel, bool>> GetCriteria(
        IFilteringRequestParameters<TEntity>? filteringRequestParameters);
}