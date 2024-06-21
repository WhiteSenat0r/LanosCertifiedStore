using System.Linq.Expressions;
using Application.Contracts.RepositoryRelated.Common;
using Domain.Contracts.Common;

namespace Persistence.Queries.Common.Contracts;

internal interface IQueryProjectionProfileSelector<TModel, TEntity>
    where TEntity : IIdentifiable<Guid>
    where TModel : class, IIdentifiable<Guid>
{
    Expression<Func<TEntity, TEntity>> GetProjectionProfile(
        IFilteringRequestParameters<TModel>? filteringRequestParameters = null!);
}