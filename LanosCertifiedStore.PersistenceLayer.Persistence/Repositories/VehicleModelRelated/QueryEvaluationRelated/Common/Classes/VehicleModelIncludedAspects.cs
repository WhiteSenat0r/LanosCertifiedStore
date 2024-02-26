using System.Linq.Expressions;
using Persistence.DataModels.VehicleRelated;

namespace Persistence.Repositories.VehicleModelRelated.QueryEvaluationRelated.Common.Classes;

internal abstract class VehicleModelIncludedAspects
{
    public static readonly List<Expression<Func<VehicleModelDataModel, object>>> IncludedAspects =
    [
        vehicleModel => vehicleModel.VehicleBrand,
        vehicleModel => vehicleModel.AvailableTypes
    ];
}