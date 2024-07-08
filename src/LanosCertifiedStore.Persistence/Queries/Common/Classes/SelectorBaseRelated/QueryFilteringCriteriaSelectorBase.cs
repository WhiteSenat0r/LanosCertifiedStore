using System.Linq.Expressions;
using Application.Shared.RequestParamsRelated;
using Domain.Contracts.Common;
using LinqKit;
using Persistence.Queries.Common.Contracts;

namespace Persistence.Queries.Common.Classes.SelectorBaseRelated;

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