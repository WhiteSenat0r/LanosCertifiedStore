using Application.Contracts.ServicesRelated.RequestRelated;
using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Application.Shared;
using Domain.Models.VehicleRelated.Classes;

namespace Application.Queries.VehicleBrandsRelated.CountVehicleBrandsQueryRelated;

internal sealed class CountVehicleBrandsQueryRequestRequestHandler(IQueryService queryService) : 
    CountItemsQueryRequestHandlerBase<
        VehicleBrand,
        CountVehicleBrandsQueryRequest,
        Tuple<int, int>,
        Result<ItemsCountDto>>(queryService);