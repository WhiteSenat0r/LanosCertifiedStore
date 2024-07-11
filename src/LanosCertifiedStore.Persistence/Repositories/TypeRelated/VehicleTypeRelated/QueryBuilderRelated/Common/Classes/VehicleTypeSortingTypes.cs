using System.Linq.Expressions;
using Domain.Entities.VehicleRelated.TypeRelated;

namespace Persistence.Repositories.TypeRelated.VehicleTypeRelated.QueryBuilderRelated.Common.Classes;

internal abstract class VehicleTypeSortingTypes
{
    public static readonly Dictionary<string, Expression<Func<VehicleType, object>>> 
        Options = new()
    {
        { "name-asc", vehicleType => vehicleType.Name },
        { "name-desc", vehicleType => vehicleType.Name },
        { "default", vehicleType => vehicleType.Name }
    };
}