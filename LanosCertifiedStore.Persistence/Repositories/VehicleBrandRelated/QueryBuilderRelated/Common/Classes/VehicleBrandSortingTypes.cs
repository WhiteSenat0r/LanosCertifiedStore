using System.Linq.Expressions;
using Domain.Entities.VehicleRelated;

namespace Persistence.Repositories.VehicleBrandRelated.QueryBuilderRelated.Common.Classes;

internal abstract class VehicleBrandSortingTypes
{
    public static readonly Dictionary<string, Expression<Func<VehicleBrand, object>>> 
        Options = new()
    {
        { "name-asc", vehicleBrand => vehicleBrand.Name },
        { "name-desc", vehicleBrand => vehicleBrand.Name },
        { "default", vehicleBrand => vehicleBrand.Name }
    };
}