using System.Linq.Expressions;
using Persistence.DataModels;

namespace Persistence.Repositories.VehicleColorRelated.QueryEvaluationRelated.Common.Classes;

internal abstract class VehicleColorIncludedAspects
{
    public static readonly List<Expression<Func<VehicleColorDataModel, object>>> IncludedAspects =
    [
        vehicleBrand => vehicleBrand.Vehicles
    ];
}