using System.Linq.Expressions;
using Persistence.DataModels.VehicleRelated;

namespace Persistence.Repositories.VehicleBrandRelated.QueryEvaluationRelated.Common.Classes;

internal abstract class VehicleBrandIncludedAspects
{
    public static readonly List<Expression<Func<VehicleBrandDataModel, object>>> IncludedAspects =
    [
        vehicleBrand => vehicleBrand.Models
    ];
}