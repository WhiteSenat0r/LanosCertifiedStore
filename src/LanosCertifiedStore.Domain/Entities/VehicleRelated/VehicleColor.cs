using Domain.Entities.Common.Classes;

namespace Domain.Entities.VehicleRelated;

public sealed class VehicleColor : NamedAspect
{
    public string HexValue { get; set; } = null!;
    public ICollection<Vehicle> Vehicles { get; set; } = [];
    
    public VehicleColor() {}

    public VehicleColor(string name, string hexValue) : base(name)
    {
        HexValue = hexValue;
    }
}
