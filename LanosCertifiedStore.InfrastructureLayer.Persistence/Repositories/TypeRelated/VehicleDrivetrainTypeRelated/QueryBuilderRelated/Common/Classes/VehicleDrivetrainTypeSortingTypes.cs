using System.Linq.Expressions;
using Persistence.DataModels.VehicleRelated.TypeRelated;

namespace Persistence.Repositories.TypeRelated.VehicleDrivetrainTypeRelated.QueryBuilderRelated.Common.Classes;

internal abstract class VehicleDrivetrainTypeSortingTypes
{
    public static readonly Dictionary<string, Expression<Func<VehicleDrivetrainTypeDataModel, object>>> 
        Options = new()
    {
        { "name-asc", vehicleDrivetrainType => vehicleDrivetrainType.Name },
        { "name-desc", vehicleDrivetrainType => vehicleDrivetrainType.Name },
        { "default", vehicleDrivetrainType => vehicleDrivetrainType.Name }
    };
}