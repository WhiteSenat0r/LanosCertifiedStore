using Application.Core.Results;
using Application.Dtos.VehicleDtos;
using Application.Queries.Common.QueryRelated;
using Application.RequestParams;
using Domain.Models.VehicleRelated.Classes;

namespace Application.Queries.Vehicles.VehiclesQueryRelated;

public sealed record VehiclesQuery(VehicleFilteringRequestParameters RequestParameters) : 
    QueryBase<Vehicle, PaginationResult<VehicleDto>>(RequestParameters, false, false);