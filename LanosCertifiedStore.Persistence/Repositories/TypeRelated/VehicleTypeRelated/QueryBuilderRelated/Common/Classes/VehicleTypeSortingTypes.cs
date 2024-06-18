using System.Linq.Expressions;
using Persistence.Entities.VehicleRelated.TypeRelated;

namespace Persistence.Repositories.TypeRelated.VehicleTypeRelated.QueryBuilderRelated.Common.Classes;

internal abstract class VehicleTypeSortingTypes
{
    public static readonly Dictionary<string, Expression<Func<VehicleTypeEntity, object>>> 
        Options = new()
    {
        { "name-asc", vehicleType => vehicleType.Name },
        { "name-desc", vehicleType => vehicleType.Name },
        { "default", vehicleType => vehicleType.Name }
    };
}