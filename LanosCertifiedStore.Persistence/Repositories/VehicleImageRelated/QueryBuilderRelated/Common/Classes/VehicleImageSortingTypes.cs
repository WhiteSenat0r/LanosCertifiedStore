using System.Linq.Expressions;
using Domain.Entities.VehicleRelated;

namespace Persistence.Repositories.VehicleImageRelated.QueryBuilderRelated.Common.Classes;

internal abstract class VehicleImageSortingTypes
{
    public static readonly Dictionary<string, Expression<Func<VehicleImage, object>>> 
        Options = new()
    {
        { "default", vehicleColor => vehicleColor.CloudImageId }
    };
}