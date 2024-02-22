using System.Linq.Expressions;
using Persistence.DataModels.VehicleRelated;

namespace Persistence.Repositories.VehicleImageRelated.QueryEvaluationRelated.Common.Classes;

internal abstract class VehicleImageIncludedAspects
{
    public static readonly List<Expression<Func<VehicleImageDataModel, object>>> IncludedAspects =
    [
        vehicleImage => vehicleImage.Vehicle
    ];
}