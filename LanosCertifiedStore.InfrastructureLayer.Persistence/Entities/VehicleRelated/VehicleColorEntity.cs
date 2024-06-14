using Persistence.Entities.Common.Classes;

namespace Persistence.Entities.VehicleRelated;

internal sealed class VehicleColorEntity : NamedVehicleAspect
{
    public string HexValue { get; set; } = null!;
    public ICollection<VehicleEntity> Vehicles { get; set; } = [];
    
    public VehicleColorEntity() {}

    public VehicleColorEntity(string name, string hexValue) : base(name)
    {
        HexValue = hexValue;
    }
}
