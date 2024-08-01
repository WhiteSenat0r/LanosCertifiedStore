using System.Linq.Expressions;
using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Domain.Contracts.Common;

namespace LanosCertifiedStore.Persistence.Queries.Common.Contracts;

public interface IQuerySortingSettingsSelector<TEntity>
    where TEntity : class, IIdentifiable<Guid>
{
    (bool IsAscending, Expression<Func<TEntity, object>> SortingSettings) GetSortingSettings(
        IFilteringRequestParameters<TEntity>? filteringRequestParameters = null!);
}