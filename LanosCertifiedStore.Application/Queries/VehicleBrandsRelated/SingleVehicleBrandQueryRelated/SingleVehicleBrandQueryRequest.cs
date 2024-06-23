using Application.Dtos.BrandDtos;
using Application.Enums.RequestParametersRelated;
using Application.Queries.Common.SingleQueryRelated;
using Application.RequestParams;
using Application.Shared;
using Domain.Models.VehicleRelated.Classes;

namespace Application.Queries.VehicleBrandsRelated.SingleVehicleBrandQueryRelated;

public sealed record SingleVehicleBrandQueryRequest(Guid Id, bool IsTracked) : 
    SingleQueryRequestBase<VehicleBrand, VehicleBrand, Result<VehicleBrandDto>, VehicleBrandDto>(
        new VehicleBrandFilteringRequestParameters
        {
            ProjectionProfile = VehicleBrandProjectionProfile.Single
        }, 
        IsTracked,
        Id);