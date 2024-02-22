using System.Linq.Expressions;
using Persistence.DataModels.VehicleRelated;

namespace Persistence.Repositories.VehicleColorRelated.QueryEvaluationRelated.Common.Classes;

internal abstract class VehicleColorSortingTypes
{
    public static readonly Dictionary<string, Expression<Func<VehicleColorDataModel, object>>> 
        Options = new()
    {
        { "name-asc", vehicleColor => vehicleColor.Name },
        { "name-desc", vehicleColor => vehicleColor.Name },
        { "default", vehicleColor => vehicleColor.Name }
    };
}