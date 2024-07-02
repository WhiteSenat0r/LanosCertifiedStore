using System.Linq.Expressions;
using Domain.Entities.VehicleRelated;

namespace Persistence.Repositories.VehiclePriceRelated.QueryBuilderRelated.Common.Classes;

internal abstract class VehiclePriceSortingTypes
{
    public static readonly Dictionary<string, Expression<Func<VehiclePrice, object>>> 
        Options = new()
    {
        { "value-asc", vehiclePrice => vehiclePrice.Value },
        { "value-desc", vehiclePrice => vehiclePrice.Value },
        { "default", vehiclePrice => vehiclePrice.Value }
    };
}