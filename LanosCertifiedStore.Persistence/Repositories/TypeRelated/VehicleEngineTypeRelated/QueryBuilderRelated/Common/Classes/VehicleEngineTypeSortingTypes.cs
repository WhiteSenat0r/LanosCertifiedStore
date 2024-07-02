using System.Linq.Expressions;
using Domain.Entities.VehicleRelated.TypeRelated;

namespace Persistence.Repositories.TypeRelated.VehicleEngineTypeRelated.QueryBuilderRelated.Common.Classes;

internal abstract class VehicleEngineTypeSortingTypes
{
    public static readonly Dictionary<string, Expression<Func<VehicleEngineType, object>>> 
        Options = new()
    {
        { "name-asc", vehicleEngineType => vehicleEngineType.Name },
        { "name-desc", vehicleEngineType => vehicleEngineType.Name },
        { "default", vehicleEngineType => vehicleEngineType.Name }
    };
}