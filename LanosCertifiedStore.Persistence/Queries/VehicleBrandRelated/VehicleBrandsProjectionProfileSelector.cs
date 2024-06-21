using System.Linq.Expressions;
using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated;
using Application.Enums.RequestParametersRelated;
using Domain.Models.VehicleRelated.Classes;
using Persistence.Entities.VehicleRelated;
using Persistence.Queries.Common.Classes.QueryRelated;

namespace Persistence.Queries.VehicleBrandRelated;

internal sealed class VehicleBrandsProjectionProfileSelector : 
    ProjectionProfileSelectorBase<VehicleBrand, VehicleBrandEntity>
{
    private protected override Expression<Func<VehicleBrandEntity, VehicleBrandEntity>> GetDefaultProfile() =>
        vehicleBrand => new VehicleBrandEntity
        {
            Id = vehicleBrand.Id,
            Name = vehicleBrand.Name
        };

    private protected override Expression<Func<VehicleBrandEntity, VehicleBrandEntity>> GetRelevantProfile(
        IFilteringRequestParameters<VehicleBrand> filteringRequestParameters)
    {
        var brandRequestParameters = (filteringRequestParameters as IVehicleBrandFilteringRequestParameters)!;
        var isDefaultProfileSelected = IsDefaultProfileSelected(brandRequestParameters);

        return isDefaultProfileSelected
            ? GetDefaultProfile()
            : GetSingleProfile();
    }
    
    private Expression<Func<VehicleBrandEntity, VehicleBrandEntity>> GetSingleProfile() =>
        vehicleBrand => new VehicleBrandEntity
        {
            Id = vehicleBrand.Id,
            Name = vehicleBrand.Name,
            Models = (vehicleBrand.Models.Select(vehicleModel => new VehicleModelEntity
            {
                Id = vehicleModel.Id,
                Name = vehicleModel.Name
            }) as ICollection<VehicleModelEntity>)!
        };

    private bool IsDefaultProfileSelected(IVehicleBrandFilteringRequestParameters brandRequestParameters) => 
        brandRequestParameters.ProjectionProfile.Equals(VehicleBrandProjectionProfile.Default);
}