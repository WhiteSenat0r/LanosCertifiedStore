using Application.Core.Results;
using Application.Dtos.ModelDtos;
using Application.Queries.Common.QueryRelated;
using Application.RequestParams;
using Application.Shared;
using Domain.Models.VehicleRelated.Classes;
using MediatR;

namespace Application.Queries.Models.ModelQueryRelated;

public sealed record ModelsQuery(VehicleModelFilteringRequestParameters RequestParameters) :
    QueryBase<VehicleModel, VehicleModelFilteringRequestParameters>(RequestParameters),
    IRequest<Result<PaginationResult<ModelDto>>>;