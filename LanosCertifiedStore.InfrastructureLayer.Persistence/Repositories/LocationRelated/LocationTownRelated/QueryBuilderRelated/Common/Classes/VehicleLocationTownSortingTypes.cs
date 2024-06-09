using System.Linq.Expressions;
using Persistence.DataModels.VehicleRelated.LocationRelated;

namespace Persistence.Repositories.LocationRelated.LocationTownRelated.QueryBuilderRelated.Common.Classes;

internal abstract class VehicleLocationTownSortingTypes
{
    public static readonly Dictionary<string, Expression<Func<VehicleLocationTownDataModel, object>>> 
        Options = new()
    {
        { "name-asc", vehicleType => vehicleType.Name },
        { "name-desc", vehicleType => vehicleType.Name },
        { "default", vehicleType => vehicleType.Name }
    };
}