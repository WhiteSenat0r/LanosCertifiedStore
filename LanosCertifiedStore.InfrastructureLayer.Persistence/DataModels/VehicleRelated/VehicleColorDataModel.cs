﻿using Persistence.DataModels.Common.Classes;

namespace Persistence.DataModels.VehicleRelated;

internal sealed class VehicleColorDataModel : NamedVehicleAspect
{
    public string HexValue { get; set; } = null!;
    public ICollection<VehicleDataModel> Vehicles { get; set; } = [];
    
    public VehicleColorDataModel() {}

    public VehicleColorDataModel(string name, string hexValue) : base(name)
    {
        HexValue = hexValue;
    }
}
