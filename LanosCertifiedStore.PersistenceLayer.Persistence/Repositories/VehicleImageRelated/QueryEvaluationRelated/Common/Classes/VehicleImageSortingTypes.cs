using System.Linq.Expressions;
using Persistence.DataModels;

namespace Persistence.Repositories.VehicleImageRelated.QueryEvaluationRelated.Common.Classes;

internal abstract class VehicleImageSortingTypes
{
    public static readonly Dictionary<string, Expression<Func<VehicleImageDataModel, object>>> 
        Options = new()
    {
        { "default", vehicleColor => vehicleColor.CloudImageId }
    };
}