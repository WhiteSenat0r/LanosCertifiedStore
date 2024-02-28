using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Enums.RequestParametersRelated;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryEvaluation.Common;

namespace Persistence.Repositories.VehicleImageRelated.QueryEvaluationRelated.Common.Classes;

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
            CloudImageId = vehicleImage.CloudImageId,
            ImageUrl = vehicleImage.ImageUrl,
            IsMainImage = vehicleImage.IsMainImage
        });
}