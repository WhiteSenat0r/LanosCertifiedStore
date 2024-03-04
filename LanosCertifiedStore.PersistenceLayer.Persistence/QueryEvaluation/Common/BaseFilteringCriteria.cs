using System.Linq.Expressions;
using Domain.Contracts.Common;
using Domain.Contracts.RepositoryRelated;
using LinqKit;
using Microsoft.IdentityModel.Tokens;

namespace Persistence.QueryEvaluation.Common;

internal abstract class BaseFilteringCriteria<TEntity, TDataModel, TParamsType> 
    where TEntity : IIdentifiable<Guid> 
    where TDataModel : class, IIdentifiable<Guid>
    where TParamsType : class, IFilteringRequestParameters<TEntity>
{
    private protected ICollection<Func<TParamsType, Expression<Func<TDataModel, bool>>>> 
        PredicateDelegates { get; } = [];
    private Expression<Func<TDataModel, bool>> QueryPredicate { get; set; } =
        PredicateBuilder.New<TDataModel>(true);
    
    internal abstract Expression<Func<TDataModel, bool>> GetCriteria(
        IFilteringRequestParameters<TEntity>? filteringRequestParameters);

    private protected abstract void AddPredicateMethodsToList(TParamsType requestParameters);
    
    private protected Expression<Func<TDataModel, bool>> GetPredicate(
        TParamsType? requestParameters = null!)
    {
        if (PredicateDelegates.IsNullOrEmpty()) return QueryPredicate;

        foreach (var predicateMethod in PredicateDelegates) 
            QueryPredicate = QueryPredicate.And(predicateMethod(requestParameters!));
        
        return QueryPredicate;
    }
}