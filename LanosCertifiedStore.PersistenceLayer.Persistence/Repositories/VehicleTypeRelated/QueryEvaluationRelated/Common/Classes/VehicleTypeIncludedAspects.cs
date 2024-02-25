using System.Linq.Expressions;
using Persistence.DataModels.VehicleRelated;

namespace Persistence.Repositories.VehicleTypeRelated.QueryEvaluationRelated.Common.Classes;

internal abstract class VehicleTypeIncludedAspects
{
    public static readonly List<Expression<Func<VehicleTypeDataModel, object>>> IncludedAspects =
    [
        vehicleBrand => vehicleBrand.Vehicles
    ];
}