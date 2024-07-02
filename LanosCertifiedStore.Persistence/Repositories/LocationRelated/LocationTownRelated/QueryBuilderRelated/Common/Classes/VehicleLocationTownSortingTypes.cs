using System.Linq.Expressions;
using Domain.Entities.VehicleRelated.LocationRelated;

namespace Persistence.Repositories.LocationRelated.LocationTownRelated.QueryBuilderRelated.Common.Classes;

internal abstract class VehicleLocationTownSortingTypes
{
    public static readonly Dictionary<string, Expression<Func<VehicleLocationTown, object>>> 
        Options = new()
    {
        { "name-asc", vehicleType => vehicleType.Name },
        { "name-desc", vehicleType => vehicleType.Name },
        { "default", vehicleType => vehicleType.Name }
    };
}