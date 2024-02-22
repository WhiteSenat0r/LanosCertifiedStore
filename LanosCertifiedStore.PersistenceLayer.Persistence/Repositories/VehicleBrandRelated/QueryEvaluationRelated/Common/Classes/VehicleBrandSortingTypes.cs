using System.Linq.Expressions;
using Persistence.DataModels.VehicleRelated;

namespace Persistence.Repositories.VehicleBrandRelated.QueryEvaluationRelated.Common.Classes;

internal abstract class VehicleBrandSortingTypes
{
    public static readonly Dictionary<string, Expression<Func<VehicleBrandDataModel, object>>> 
        Options = new()
    {
        { "name-asc", vehicleBrand => vehicleBrand.Name },
        { "name-desc", vehicleBrand => vehicleBrand.Name },
        { "default", vehicleBrand => vehicleBrand.Name }
    };
}