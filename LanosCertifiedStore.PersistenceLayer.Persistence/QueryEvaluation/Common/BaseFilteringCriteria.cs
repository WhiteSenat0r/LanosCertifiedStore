using System.Linq.Expressions;
using Domain.Contracts.Common;
using Domain.Contracts.RepositoryRelated;

namespace Persistence.QueryEvaluation.Common;

internal abstract class BaseFilteringCriteria<TEntity, TDataModel> 
  where TEntity : IIdentifiable<Guid>
  where TDataModel : class, IIdentifiable<Guid>
{
    internal abstract Expression<Func<TDataModel, bool>> GetCriteria(
        IFilteringRequestParameters<TEntity>? filteringRequestParameters);
}