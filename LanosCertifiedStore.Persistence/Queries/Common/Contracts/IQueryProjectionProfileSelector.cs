using System.Linq.Expressions;
using Application.Contracts.RepositoryRelated.Common;
using Domain.Contracts.Common;

namespace Persistence.Queries.Common.Contracts;

public interface IQueryProjectionProfileSelector<TEntity>
    where TEntity : class, IIdentifiable<Guid>
{
    Expression<Func<TEntity, TEntity>> GetProjectionProfile(
        IFilteringRequestParameters<TEntity>? filteringRequestParameters = null!);
}