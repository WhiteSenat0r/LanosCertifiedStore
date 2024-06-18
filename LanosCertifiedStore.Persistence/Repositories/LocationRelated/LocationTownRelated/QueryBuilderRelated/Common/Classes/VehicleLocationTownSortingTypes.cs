using System.Linq.Expressions;
using Persistence.Entities.VehicleRelated.LocationRelated;

namespace Persistence.Repositories.LocationRelated.LocationTownRelated.QueryBuilderRelated.Common.Classes;

internal abstract class VehicleLocationTownSortingTypes
{
    public static readonly Dictionary<string, Expression<Func<VehicleLocationTownEntity, object>>> 
        Options = new()
    {
        { "name-asc", vehicleType => vehicleType.Name },
        { "name-desc", vehicleType => vehicleType.Name },
        { "default", vehicleType => vehicleType.Name }
    };
}