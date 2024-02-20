using System.Linq.Expressions;
using Domain.Contracts.Common;

namespace Persistence.QueryEvaluation.Common;

internal abstract class BaseSortingSettings<TDataModel>(
    Expression<Func<TDataModel, object>>? orderByAscendingExpression = null!,
    Expression<Func<TDataModel, object>>? orderByDescendingExpression = null!)
    where TDataModel : class, IIdentifiable<Guid>
{
    public Expression<Func<TDataModel, object>>?
        OrderByAscendingExpression { get; set; } = orderByAscendingExpression;

    public Expression<Func<TDataModel, object>>?
        OrderByDescendingExpression { get; set; } = orderByDescendingExpression;
}