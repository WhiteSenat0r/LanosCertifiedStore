using System.Linq.Expressions;
using Persistence.Entities.VehicleRelated;

namespace Persistence.Repositories.VehicleColorRelated.QueryBuilderRelated.Common.Classes;

internal abstract class VehicleColorSortingTypes
{
    public static readonly Dictionary<string, Expression<Func<VehicleColorEntity, object>>> 
        Options = new()
    {
        { "name-asc", vehicleColor => vehicleColor.Name },
        { "name-desc", vehicleColor => vehicleColor.Name },
        { "default", vehicleColor => vehicleColor.Name }
    };
}