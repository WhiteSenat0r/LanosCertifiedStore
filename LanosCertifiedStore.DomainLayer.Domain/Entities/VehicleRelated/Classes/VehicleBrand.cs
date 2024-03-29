﻿using Domain.Entities.VehicleRelated.Classes.Common.Classes;

namespace Domain.Entities.VehicleRelated.Classes;

public sealed class VehicleBrand : NamedVehicleAspect
{
    public ICollection<VehicleModel> Models { get; init; } = [];
    
    public VehicleBrand() { }
    
    public VehicleBrand(string name) : base(name) {}
}
