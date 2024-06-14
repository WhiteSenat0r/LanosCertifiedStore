using System.Linq.Expressions;
using Persistence.Entities.VehicleRelated;

namespace Persistence.Repositories.VehicleModelRelated.QueryBuilderRelated.Common.Classes;

internal abstract class VehicleModelSortingTypes
{
    public static readonly Dictionary<string, Expression<Func<VehicleModelEntity, object>>> 
        Options = new()
    {
        { "name-asc", vehicleModel => vehicleModel.Name },
        { "name-desc", vehicleModel => vehicleModel.Name },
        { "brand-name-asc", vehicleModel => vehicleModel.VehicleBrand.Name },
        { "brand-name-desc", vehicleModel => vehicleModel.VehicleBrand.Name },
        { "default", vehicleModel => vehicleModel.Name }
    };
}