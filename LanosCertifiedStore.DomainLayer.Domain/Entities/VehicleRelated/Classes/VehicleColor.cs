using Domain.Entities.VehicleRelated.Classes.Common.Classes;

namespace Domain.Entities.VehicleRelated.Classes;

public sealed class VehicleColor : NamedVehicleAspect
{
    public string HexValue { get; set; } = null!;
    public ICollection<Vehicle> Vehicles { get; init; } = [];
    
    public VehicleColor() {}

    public VehicleColor(string name, string hexValue) : base(name) => HexValue = hexValue;
}
