using System.Linq.Expressions;
using Application.Contracts.RepositoryRelated.Common;
using Domain.Contracts.Common;

namespace Persistence.Queries.Common.Contracts;

public interface IQuerySortingSettingsSelector<TEntity>
    where TEntity : class, IIdentifiable<Guid>
{
    (bool IsAscending, Expression<Func<TEntity, object>> SortingSettings) GetSortingSettings(
        IFilteringRequestParameters<TEntity>? filteringRequestParameters = null!);
}