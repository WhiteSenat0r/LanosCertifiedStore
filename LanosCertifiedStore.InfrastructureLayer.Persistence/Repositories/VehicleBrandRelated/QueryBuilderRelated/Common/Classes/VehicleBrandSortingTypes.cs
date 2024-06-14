using System.Linq.Expressions;
using Persistence.Entities.VehicleRelated;

namespace Persistence.Repositories.VehicleBrandRelated.QueryBuilderRelated.Common.Classes;

internal abstract class VehicleBrandSortingTypes
{
    public static readonly Dictionary<string, Expression<Func<VehicleBrandEntity, object>>> 
        Options = new()
    {
        { "name-asc", vehicleBrand => vehicleBrand.Name },
        { "name-desc", vehicleBrand => vehicleBrand.Name },
        { "default", vehicleBrand => vehicleBrand.Name }
    };
}