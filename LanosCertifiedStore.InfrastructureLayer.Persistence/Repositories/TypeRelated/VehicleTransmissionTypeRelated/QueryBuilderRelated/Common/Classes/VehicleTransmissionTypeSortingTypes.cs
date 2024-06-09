using System.Linq.Expressions;
using Persistence.DataModels.VehicleRelated.TypeRelated;

namespace Persistence.Repositories.TypeRelated.VehicleTransmissionTypeRelated.QueryBuilderRelated.Common.Classes;

internal abstract class VehicleTransmissionTypeSortingTypes
{
    public static readonly Dictionary<string, Expression<Func<VehicleTransmissionTypeDataModel, object>>> 
        Options = new()
    {
        { "name-asc", vehicleTransmissionType => vehicleTransmissionType.Name },
        { "name-desc", vehicleTransmissionType => vehicleTransmissionType.Name },
        { "default", vehicleTransmissionType => vehicleTransmissionType.Name }
    };
}