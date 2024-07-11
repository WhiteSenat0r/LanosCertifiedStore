using System.Linq.Expressions;
using Domain.Entities.VehicleRelated.LocationRelated;

namespace Persistence.Repositories.LocationRelated.LocationAreaRelated.QueryBuilderRelated.Common.Classes;

internal abstract class VehicleLocationAreaSortingTypes
{
    public static readonly Dictionary<string, Expression<Func<VehicleLocationArea, object>>> 
        Options = new()
    {
        { "name-asc", vehicleType => vehicleType.Name },
        { "name-desc", vehicleType => vehicleType.Name },
        { "default", vehicleType => vehicleType.Name }
    };
}