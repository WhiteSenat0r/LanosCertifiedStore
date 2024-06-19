using System.Linq.Expressions;
using Domain.Contracts.Common;

namespace Persistence.Queries.Common.Contracts;

internal interface IQuerySortingSettingsSelector<TEntity>
    where TEntity : class, IIdentifiable<Guid>
{
    (bool IsAscending, Expression<Func<TEntity, object>> SortingSettings) GetSortingSettings();
}