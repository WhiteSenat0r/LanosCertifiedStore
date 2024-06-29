using System.Linq.Expressions;
using Application.Contracts.RepositoryRelated.Common;
using Domain.Contracts.Common;
using Persistence.Queries.Common.Contracts;

namespace Persistence.Queries.Common.Classes.SelectorBaseRelated;

internal abstract class ProjectionProfileSelectorBase<TModel, TEntity> : 
    IQueryProjectionProfileSelector<TModel, TEntity> 
    where TModel : class, IIdentifiable<Guid>
    where TEntity : class, IIdentifiable<Guid>
{
    public Expression<Func<TEntity, TEntity>> GetProjectionProfile(
        IFilteringRequestParameters<TModel>? filteringRequestParameters = null!)
    {
        return filteringRequestParameters is null 
            ? GetDefaultProfile() 
            : GetRelevantProfile(filteringRequestParameters);
    }

    private protected abstract Expression<Func<TEntity, TEntity>> GetDefaultProfile();

    private protected abstract Expression<Func<TEntity, TEntity>> GetRelevantProfile(
        IFilteringRequestParameters<TModel> filteringRequestParameters);
}