using Application.Contracts.RequestParametersRelated;
using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Application.Shared;
using Domain.Models.VehicleRelated.Classes;

namespace Application.Queries.VehicleBrandsRelated.CountVehicleBrandsQueryRelated;

public sealed record CountVehicleBrandsQueryRequest(
    IVehicleBrandFilteringRequestParameters RequestParameters) : 
    CountItemsQueryRequestBase<VehicleBrand, Tuple<int, int>, Result<ItemsCountDto>>(RequestParameters, false);