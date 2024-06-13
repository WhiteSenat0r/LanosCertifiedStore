using Application.Contracts.RepositoryRelated.Common;
using Application.Enums.RequestParametersRelated;
using Domain.Entities.VehicleRelated.Classes;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.VehicleImageRelated.QueryBuilderRelated.Common.Classes;

internal class VehicleImageSelectionProfiles : 
    BaseSelectionProfiles<VehicleImageSelectionProfile, VehicleImage, VehicleImageDataModel>
{
    private readonly Dictionary<VehicleImageSelectionProfile,
            Func<IQueryable<VehicleImageDataModel>, IQueryable<VehicleImageDataModel>>>
        _mappedProfiles = new()
        {
            { VehicleImageSelectionProfile.Default, GetDefaultProfileQueryable }
        };

    public override IQueryable<VehicleImageDataModel> GetSuitableSelectionProfileQueryable(
        IQueryable<VehicleImageDataModel> inputQueryable,
        IFilteringRequestParameters<VehicleImage>? requestParameters = null) =>
        _mappedProfiles[VehicleImageSelectionProfile.Default](inputQueryable);

    private static IQueryable<VehicleImageDataModel> GetDefaultProfileQueryable(
        IQueryable<VehicleImageDataModel> queryable) =>
        queryable.Select(vehicleImage => new VehicleImageDataModel
        {
            Id = vehicleImage.Id,
            ImageUrl = vehicleImage.ImageUrl,
            IsMainImage = vehicleImage.IsMainImage
        });
}