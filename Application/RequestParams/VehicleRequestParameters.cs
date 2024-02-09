using Application.RequestParams.Common.Classes;

namespace Application.RequestParams;

public sealed class VehicleRequestParameters : RequestParameters
{
    public string Brand { get; set; }
    
    public string Type { get; set; }
    
    public string Color { get; set; }
    
    public decimal? Displacement { get; set; }
    
    public decimal? LowerPriceLimit { get; set; }
    
    public decimal? UpperPriceLimit { get; set; }
    
    public DateTime? MinimalPriceDate { get; set; }
}