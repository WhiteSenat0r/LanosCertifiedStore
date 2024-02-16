using System.Linq.Expressions;
using Persistence.DataModels;

namespace Persistence.Repositories.VehiclePriceRelated.QueryEvaluationRelated.Common.Classes;

internal abstract class VehiclePriceSortingTypes
{
    public static readonly Dictionary<string, Expression<Func<VehiclePriceDataModel, object>>> 
        Options = new()
    {
        { "value-asc", vehiclePrice => vehiclePrice.Value },
        { "value-desc", vehiclePrice => vehiclePrice.Value },
        { "default", vehiclePrice => vehiclePrice.Value }
    };
}