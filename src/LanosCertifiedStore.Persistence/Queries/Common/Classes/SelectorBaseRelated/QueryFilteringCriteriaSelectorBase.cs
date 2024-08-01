using System.Linq.Expressions;
using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Domain.Contracts.Common;
using LanosCertifiedStore.Persistence.Queries.Common.Contracts;
using LinqKit;

namespace LanosCertifiedStore.Persistence.Queries.Common.Classes.SelectorBaseRelated;

internal abstract class QueryFilteringCriteriaSelectorBase<TEntity> : 
    IQueryFilteringCriteriaSelector<TEntity>
    where TEntity : class, IIdentifiable<Guid>
{
    private Expression<Func<TEntity, bool>> _filteringCriteriaExpression = 
        PredicateBuilder.New<TEntity>(true);

    public Expression<Func<TEntity, bool>> GetCriteria(
        IFilteringRequestParameters<TEntity>? filteringRequestParameters = null)
    {
        var aspects = GetAspectMappings(filteringRequestParameters!);

        TryApplyCriteriaAspects(aspects);

        return _filteringCriteriaExpression;
    }

    private void TryApplyCriteriaAspects(
        IReadOnlyCollection<(bool IsValid, Expression<Func<TEntity, bool>> Expression)> aspects)
    {
        foreach (var aspect in aspects)
        {
            if (aspect.IsValid)
            {
                AddFilteringCriteriaAspect(aspect.Expression);
            }
        }
    }

    private void AddFilteringCriteriaAspect(Expression<Func<TEntity, bool>> aspectExpression)
    {
        _filteringCriteriaExpression = _filteringCriteriaExpression.And(aspectExpression);
    }

    private protected abstract IReadOnlyCollection<(bool IsValid, Expression<Func<TEntity, bool>> Expression)> 
        GetAspectMappings(IFilteringRequestParameters<TEntity> filteringRequestParameters);
}