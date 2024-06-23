using Application.Contracts.ServicesRelated.RequestRelated;
using Application.Dtos.BrandDtos;
using Application.Queries.Common.SingleQueryRelated;
using Application.Shared;
using AutoMapper;
using Domain.Models.VehicleRelated.Classes;

namespace Application.Queries.VehicleBrandsRelated.SingleVehicleBrandQueryRelated;

internal sealed class SingleVehicleBrandQueryRequestHandler(
    IQueryService queryService,
    IMapper mapper) :
    SingleQueryRequestHandlerBase<
        SingleVehicleBrandQueryRequest,
        VehicleBrand,
        VehicleBrand,
        Result<VehicleBrandDto>,
        VehicleBrandDto>(queryService, mapper);
