using Application.Contracts.RepositoryRelated.Common;
using Application.Enums.RequestParametersRelated;
using Domain.Models.VehicleRelated.Classes;
using Persistence.Entities.VehicleRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.VehicleImageRelated.QueryBuilderRelated.Common.Classes;

internal class VehicleImageSelectionProfiles : 
    BaseSelectionProfiles<VehicleImageSelectionProfile, VehicleImage, VehicleImageEntity>
{
    private readonly Dictionary<VehicleImageSelectionProfile,
            Func<IQueryable<VehicleImageEntity>, IQueryable<VehicleImageEntity>>>
        _mappedProfiles = new()
        {
            { VehicleImageSelectionProfile.Default, GetDefaultProfileQueryable }
        };

    public override IQueryable<VehicleImageEntity> GetSuitableSelectionProfileQueryable(
        IQueryable<VehicleImageEntity> inputQueryable,
        IFilteringRequestParameters<VehicleImage>? requestParameters = null) =>
        _mappedProfiles[VehicleImageSelectionProfile.Default](inputQueryable);

    private static IQueryable<VehicleImageEntity> GetDefaultProfileQueryable(
        IQueryable<VehicleImageEntity> queryable) =>
        queryable.Select(vehicleImage => new VehicleImageEntity
        {
            Id = vehicleImage.Id,
            ImageUrl = vehicleImage.ImageUrl,
            IsMainImage = vehicleImage.IsMainImage
        });
}