using System.Linq.Expressions;
using Persistence.DataModels.VehicleRelated.TypeRelated;

namespace Persistence.Repositories.TypeRelated.VehicleEngineTypeRelated.QueryBuilderRelated.Common.Classes;

internal abstract class VehicleEngineTypeSortingTypes
{
    public static readonly Dictionary<string, Expression<Func<VehicleEngineTypeDataModel, object>>> 
        Options = new()
    {
        { "name-asc", vehicleEngineType => vehicleEngineType.Name },
        { "name-desc", vehicleEngineType => vehicleEngineType.Name },
        { "default", vehicleEngineType => vehicleEngineType.Name }
    };
}