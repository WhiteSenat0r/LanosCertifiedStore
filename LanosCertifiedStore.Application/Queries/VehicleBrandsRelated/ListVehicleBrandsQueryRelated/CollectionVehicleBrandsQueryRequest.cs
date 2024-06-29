using Application.Contracts.RequestParametersRelated;
using Application.Core.Results;
using Application.Dtos.BrandDtos;
using Application.Queries.Common.CollectionQueryRelated;
using Application.Shared.ResultRelated;
using Domain.Models.VehicleRelated.Classes;

namespace Application.Queries.VehicleBrandsRelated.ListVehicleBrandsQueryRelated;

public sealed record CollectionVehicleBrandsQueryRequest(
    IVehicleBrandFilteringRequestParameters RequestParameters, bool IsTracked) :
    CollectionQueryRequestBase<
        VehicleBrand,
        IReadOnlyCollection<VehicleBrand>,
        Result<PaginationResult<VehicleBrandDto>>,
        VehicleBrandDto>(RequestParameters, IsTracked);