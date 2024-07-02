using System.Linq.Expressions;
using Domain.Entities.VehicleRelated.TypeRelated;

namespace Persistence.Repositories.TypeRelated.VehicleBodyTypeRelated.QueryBuilderRelated.Common.Classes;

internal abstract class VehicleBodyTypeSortingTypes
{
    public static readonly Dictionary<string, Expression<Func<VehicleBodyType, object>>> 
        Options = new()
    {
        { "name-asc", vehicleBodyType => vehicleBodyType.Name },
        { "name-desc", vehicleBodyType => vehicleBodyType.Name },
        { "default", vehicleBodyType => vehicleBodyType.Name }
    };
}