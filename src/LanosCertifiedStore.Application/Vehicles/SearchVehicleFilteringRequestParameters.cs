namespace LanosCertifiedStore.Application.Vehicles;

public sealed class SearchVehicleFilteringRequestParameters : VehicleFilteringRequestParameters,
    ISearchVehicleFilteringRequestParameters
{
    public string SearchTerm { get; set; } = null!;
}