using Application.Shared.RequestParamsRelated;
using Domain.Contracts.Common;

namespace Persistence.QueryBuilder.Common;

internal abstract class BaseSelectionProfiles<TSelectionProfile, TEntity, TDataModel>
    where TSelectionProfile : struct, Enum
    where TEntity : IIdentifiable<Guid>
    where TDataModel : class, IIdentifiable<Guid>
{
    public abstract IQueryable<TDataModel> GetSuitableSelectionProfileQueryable(
        IQueryable<TDataModel> inputQueryable,
        IFilteringRequestParameters<TEntity>? requestParameters = null);
}