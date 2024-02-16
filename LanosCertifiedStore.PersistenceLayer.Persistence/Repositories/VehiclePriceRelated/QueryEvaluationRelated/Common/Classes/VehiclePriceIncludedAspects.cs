using System.Linq.Expressions;
using Persistence.DataModels;

namespace Persistence.Repositories.VehiclePriceRelated.QueryEvaluationRelated.Common.Classes;

internal abstract class VehiclePriceIncludedAspects
{
    public static readonly List<Expression<Func<VehiclePriceDataModel, object>>> IncludedAspects =
    [
        vehiclePrice => vehiclePrice.Vehicle,
    ];
}