﻿using Application.RequestParams.Common.Classes;
using Domain.Contracts.RequestParametersRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Enums.RequestParametersRelated;

namespace Application.RequestParams;

public sealed class VehicleFilteringRequestParameters : BaseFilteringRequestParameters<Vehicle>,
    IVehicleFilteringRequestParameters
{
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public string? Type { get; set; }
    public string? Color { get; set; }
    public decimal? LowerPriceLimit { get; set; }
    public decimal? UpperPriceLimit { get; set; }
    public VehicleSelectionProfile SelectionProfile { get; set; } = VehicleSelectionProfile.Default;
}