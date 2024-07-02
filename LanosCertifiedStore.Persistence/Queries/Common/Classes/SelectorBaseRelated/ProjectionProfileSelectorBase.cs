using System.Linq.Expressions;
using Application.Contracts.RepositoryRelated.Common;
using Domain.Contracts.Common;
using Persistence.Queries.Common.Contracts;

namespace Persistence.Queries.Common.Classes.SelectorBaseRelated;

internal abstract class ProjectionProfileSelectorBase<TEntity> : 
    IQueryProjectionProfileSelector<TEntity>
    where TEntity : class, IIdentifiable<Guid>
{
    public Expression<Func<TEntity, TEntity>> GetProjectionProfile(
        IFilteringRequestParameters<TEntity>? filteringRequestParameters = null!)
    {
        return filteringRequestParameters is null 
            ? GetDefaultProfile() 
            : GetRelevantProfile(filteringRequestParameters);
    }

    private protected abstract Expression<Func<TEntity, TEntity>> GetDefaultProfile();

    private protected abstract Expression<Func<TEntity, TEntity>> GetRelevantProfile(
        IFilteringRequestParameters<TEntity> filteringRequestParameters);
}