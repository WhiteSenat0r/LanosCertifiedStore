using System.Linq.Expressions;
using Domain.Contracts.Common;

namespace Persistence.Queries.Common.Contracts;

internal interface IQuerySelectionProfileSelector<TEntity>
    where TEntity : IIdentifiable<Guid>
{
    Expression<Func<TEntity,TEntity>> GetSelectionProfile();
}