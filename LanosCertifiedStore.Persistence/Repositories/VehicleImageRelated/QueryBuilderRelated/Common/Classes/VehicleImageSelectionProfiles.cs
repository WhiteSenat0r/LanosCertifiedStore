using Application.Contracts.RepositoryRelated.Common;
using Application.Enums.RequestParametersRelated;
using Domain.Entities.VehicleRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.VehicleImageRelated.QueryBuilderRelated.Common.Classes;

internal class VehicleImageSelectionProfiles : 
    BaseSelectionProfiles<VehicleImageSelectionProfile, VehicleImage, VehicleImage>
{
    private readonly Dictionary<VehicleImageSelectionProfile,
            Func<IQueryable<VehicleImage>, IQueryable<VehicleImage>>>
        _mappedProfiles = new()
        {
            { VehicleImageSelectionProfile.Default, GetDefaultProfileQueryable }
        };

    public override IQueryable<VehicleImage> GetSuitableSelectionProfileQueryable(
        IQueryable<VehicleImage> inputQueryable,
        IFilteringRequestParameters<VehicleImage>? requestParameters = null) =>
        _mappedProfiles[VehicleImageSelectionProfile.Default](inputQueryable);

    private static IQueryable<VehicleImage> GetDefaultProfileQueryable(
        IQueryable<VehicleImage> queryable) =>
        queryable.Select(vehicleImage => new VehicleImage
        {
            Id = vehicleImage.Id,
            ImageUrl = vehicleImage.ImageUrl,
            IsMainImage = vehicleImage.IsMainImage
        });
}