using System.Linq.Expressions;
using Domain.Entities.VehicleRelated;

namespace Persistence.Repositories.VehicleColorRelated.QueryBuilderRelated.Common.Classes;

internal abstract class VehicleColorSortingTypes
{
    public static readonly Dictionary<string, Expression<Func<VehicleColor, object>>> 
        Options = new()
    {
        { "name-asc", vehicleColor => vehicleColor.Name },
        { "name-desc", vehicleColor => vehicleColor.Name },
        { "default", vehicleColor => vehicleColor.Name }
    };
}