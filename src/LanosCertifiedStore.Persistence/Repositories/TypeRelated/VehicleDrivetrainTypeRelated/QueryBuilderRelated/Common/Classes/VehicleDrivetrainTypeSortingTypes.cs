using System.Linq.Expressions;
using Domain.Entities.VehicleRelated.TypeRelated;

namespace Persistence.Repositories.TypeRelated.VehicleDrivetrainTypeRelated.QueryBuilderRelated.Common.Classes;

internal abstract class VehicleDrivetrainTypeSortingTypes
{
    public static readonly Dictionary<string, Expression<Func<VehicleDrivetrainType, object>>> 
        Options = new()
    {
        { "name-asc", vehicleDrivetrainType => vehicleDrivetrainType.Name },
        { "name-desc", vehicleDrivetrainType => vehicleDrivetrainType.Name },
        { "default", vehicleDrivetrainType => vehicleDrivetrainType.Name }
    };
}