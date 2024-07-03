using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestRelated.QueryRelated;
using Application.Dtos.BrandDtos;
using Application.Enums.RequestParametersRelated;
using Application.RequestParameters;
using Domain.Entities.VehicleRelated;

namespace Application.QueryRequests.VehicleBrandsRelated.SingleVehicleBrandQueryRelated;

public sealed record SingleVehicleBrandQueryRequest(
    Guid ItemId) : ISingleQueryRequest<VehicleBrand, VehicleBrandWithRelatedModelsDto>
{
    public IFilteringRequestParameters<VehicleBrand> FilteringParameters => new VehicleBrandFilteringRequestParameters
    {
        ProjectionProfile = VehicleBrandProjectionProfile.Single
    };
}