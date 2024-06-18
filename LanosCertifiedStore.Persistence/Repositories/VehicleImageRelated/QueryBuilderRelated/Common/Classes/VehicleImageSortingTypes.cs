using System.Linq.Expressions;
using Persistence.Entities.VehicleRelated;

namespace Persistence.Repositories.VehicleImageRelated.QueryBuilderRelated.Common.Classes;

internal abstract class VehicleImageSortingTypes
{
    public static readonly Dictionary<string, Expression<Func<VehicleImageEntity, object>>> 
        Options = new()
    {
        { "default", vehicleColor => vehicleColor.CloudImageId }
    };
}