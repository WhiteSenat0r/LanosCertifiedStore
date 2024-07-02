using System.Linq.Expressions;
using Domain.Entities.VehicleRelated.LocationRelated;

namespace Persistence.Repositories.LocationRelated.LocationRegionRelated.QueryBuilderRelated.Common.Classes;

internal abstract class VehicleLocationRegionSortingTypes
{
    public static readonly Dictionary<string, Expression<Func<VehicleLocationRegion, object>>> 
        Options = new()
    {
        { "name-asc", vehicleType => vehicleType.Name },
        { "name-desc", vehicleType => vehicleType.Name },
        { "default", vehicleType => vehicleType.Name }
    };
}