namespace LanosCertifiedStore.Application.Vehicles;

public interface ISearchVehicleFilteringRequestParameters : IVehicleFilteringRequestParameters
{
    public string SearchTerm { get; set; }
}