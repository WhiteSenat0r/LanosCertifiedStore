using Domain.Entities.VehicleRelated.Classes.Common.Classes;

namespace Domain.Entities.VehicleRelated.Classes;

public sealed class VehicleModel : NamedVehicleAspect
{
    public Guid VehicleBrandId { get; set; }
    public VehicleBrand VehicleBrand { get; set; }
    
    public VehicleModel() {}

    public VehicleModel(Guid vehicleBrandId, string name) : base(name) =>
        VehicleBrandId = vehicleBrandId;
}
