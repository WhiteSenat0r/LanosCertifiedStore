﻿using Application.Contracts.RequestParametersRelated.LocationRelated;
using Application.Enums.RequestParametersRelated.LocationRelated;
using Application.RequestParams.Common.Classes;
using Domain.Entities.VehicleRelated.LocationRelated;

namespace Application.RequestParams.LocationRelated;

public sealed class VehicleLocationRegionFilteringRequestParameters : 
    BaseFilteringRequestParameters<VehicleLocationRegion>,
    IVehicleLocationRegionFilteringRequestParameters
{
    public string? Name { get; set; }
    public VehicleLocationRegionSelectionProfile SelectionProfile => VehicleLocationRegionSelectionProfile.Default;
}