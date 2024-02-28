using Domain.Contracts.Common;
using Domain.Contracts.RepositoryRelated;
using Persistence.DataModels.VehicleRelated;

namespace Persistence.QueryEvaluation.Common;

internal abstract class BaseSelectionProfiles<TSelectionProfile, TEntity, TDataModel>
    where TSelectionProfile : struct, Enum
    where TEntity : IIdentifiable<Guid>
    where TDataModel : class, IIdentifiable<Guid>
{
    public abstract IQueryable<VehicleBrandDataModel> GetSuitableSelectionProfileQueryable(
        IQueryable<TDataModel> inputQueryable,
        IFilteringRequestParameters<TEntity>? requestParameters = null);
}