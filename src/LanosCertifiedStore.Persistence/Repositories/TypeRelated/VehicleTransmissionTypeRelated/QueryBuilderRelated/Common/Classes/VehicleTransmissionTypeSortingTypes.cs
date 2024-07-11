using System.Linq.Expressions;
using Domain.Entities.VehicleRelated.TypeRelated;

namespace Persistence.Repositories.TypeRelated.VehicleTransmissionTypeRelated.QueryBuilderRelated.Common.Classes;

internal abstract class VehicleTransmissionTypeSortingTypes
{
    public static readonly Dictionary<string, Expression<Func<VehicleTransmissionType, object>>> 
        Options = new()
    {
        { "name-asc", vehicleTransmissionType => vehicleTransmissionType.Name },
        { "name-desc", vehicleTransmissionType => vehicleTransmissionType.Name },
        { "default", vehicleTransmissionType => vehicleTransmissionType.Name }
    };
}