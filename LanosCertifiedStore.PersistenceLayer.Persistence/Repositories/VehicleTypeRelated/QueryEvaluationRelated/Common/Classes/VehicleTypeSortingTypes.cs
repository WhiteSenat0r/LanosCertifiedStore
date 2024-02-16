using System.Linq.Expressions;
using Persistence.DataModels;

namespace Persistence.Repositories.VehicleTypeRelated.QueryEvaluationRelated.Common.Classes;

internal abstract class VehicleTypeSortingTypes
{
    public static readonly Dictionary<string, Expression<Func<VehicleTypeDataModel, object>>> 
        Options = new()
    {
        { "name-asc", vehicleType => vehicleType.Name },
        { "name-desc", vehicleType => vehicleType.Name },
        { "default", vehicleType => vehicleType.Name }
    };
}