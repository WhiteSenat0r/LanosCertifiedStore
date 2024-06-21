using System.Linq.Expressions;
using Application.Contracts.RepositoryRelated.Common;
using Domain.Contracts.Common;

namespace Persistence.Queries.Common.Contracts;

internal interface IQuerySortingSettingsSelector<TModel, TEntity>
    where TModel : class, IIdentifiable<Guid>
    where TEntity : class, IIdentifiable<Guid>
{
    (bool IsAscending, Expression<Func<TEntity, object>> SortingSettings) GetSortingSettings(
        IFilteringRequestParameters<TModel>? filteringRequestParameters = null!);
}