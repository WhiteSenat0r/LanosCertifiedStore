using Application.RequestParams.Common.Classes;
using Domain.Contracts.RequestParametersRelated;
using Domain.Entities.VehicleRelated.Classes;

namespace Application.RequestParams;

public sealed class VehicleFilteringRequestParameters(int maxItemsQuantity) 
    : BaseFilteringRequestParameters<Vehicle>(maxItemsQuantity), IVehicleFilteringRequestParameters
{
    public string Brand { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Color { get; set; } = null!;

    public double Displacement { get; set; }
    
    public decimal LowerPriceLimit { get; set; }
    
    public decimal UpperPriceLimit { get; set; }
    
    public DateTime MinimalPriceDate { get; set; }
}