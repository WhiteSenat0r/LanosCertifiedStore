using System.Linq.Expressions;
using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated;
using Application.Enums.RequestParametersRelated;
using Domain.Entities.VehicleRelated;
using Persistence.Queries.Common.Classes.SelectorBaseRelated;

namespace Persistence.Queries.VehicleBrandRelated.SelectorRelated;

internal sealed class VehicleBrandsProjectionProfileSelector : 
    ProjectionProfileSelectorBase<VehicleBrand>
{
    private protected override Expression<Func<VehicleBrand, VehicleBrand>> GetDefaultProfile() =>
        vehicleBrand => new VehicleBrand
        {
            Id = vehicleBrand.Id,
            Name = vehicleBrand.Name
        };

    private protected override Expression<Func<VehicleBrand, VehicleBrand>> GetRelevantProfile(
        IFilteringRequestParameters<VehicleBrand> filteringRequestParameters)
    {
        var brandRequestParameters = (filteringRequestParameters as IVehicleBrandFilteringRequestParameters)!;
        var isDefaultProfileSelected = IsDefaultProfileSelected(brandRequestParameters);

        return isDefaultProfileSelected
            ? GetDefaultProfile()
            : GetSingleProfile();
    }
    
    private Expression<Func<VehicleBrand, VehicleBrand>> GetSingleProfile() =>
        vehicleBrand => new VehicleBrand
        {
            Id = vehicleBrand.Id,
            Name = vehicleBrand.Name,
            Models = (vehicleBrand.Models.Select(vehicleModel => new VehicleModel
            {
                Id = vehicleModel.Id,
                Name = vehicleModel.Name
            }) as ICollection<VehicleModel>)!
        };

    private bool IsDefaultProfileSelected(IVehicleBrandFilteringRequestParameters brandRequestParameters) => 
        brandRequestParameters.ProjectionProfile.Equals(VehicleBrandProjectionProfile.Default);
}