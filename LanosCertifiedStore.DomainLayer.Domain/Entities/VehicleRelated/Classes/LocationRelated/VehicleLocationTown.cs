﻿using Domain.Entities.VehicleRelated.Classes.Common.Classes;

namespace Domain.Entities.VehicleRelated.Classes.LocationRelated;

public sealed class VehicleLocationTown : NamedVehicleAspect
{
    public VehicleLocationArea LocationArea { get; init; } = null!;
    public VehicleLocationRegion LocationRegion { get; init; } = null!;

    public VehicleLocationTown() { }
    
    public VehicleLocationTown(string name,
        VehicleLocationArea locationArea,
        VehicleLocationRegion locationRegion) : base(name)
    {
        LocationArea = locationArea;
        LocationRegion = locationRegion;
    }
}