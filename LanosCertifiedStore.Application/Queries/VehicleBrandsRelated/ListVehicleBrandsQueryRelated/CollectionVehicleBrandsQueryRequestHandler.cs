using Application.Contracts.ServicesRelated.RequestRelated;
using Application.Core.Results;
using Application.Dtos.BrandDtos;
using Application.Queries.Common.CollectionQueryRelated;
using Application.Shared.ResultRelated;
using AutoMapper;
using Domain.Models.VehicleRelated.Classes;

namespace Application.Queries.VehicleBrandsRelated.ListVehicleBrandsQueryRelated;

internal sealed class CollectionVehicleBrandsQueryRequestHandler(IQueryService queryService, IMapper mapper) :
    CollectionQueryHandlerBase<
        CollectionVehicleBrandsQueryRequest,
        VehicleBrand,
        IReadOnlyCollection<VehicleBrand>,
        Result<PaginationResult<VehicleBrandDto>>,
        VehicleBrandDto>(queryService, mapper);