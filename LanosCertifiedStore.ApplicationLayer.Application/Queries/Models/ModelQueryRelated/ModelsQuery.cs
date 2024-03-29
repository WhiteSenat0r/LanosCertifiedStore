﻿using Application.Core.Results;
using Application.Dtos.ModelDtos;
using Application.Queries.Common.QueryRelated;
using Application.RequestParams;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Models.ModelQueryRelated;

public sealed record ModelsQuery(VehicleModelFilteringRequestParameters RequestParameters) :
    ListQueryBase<VehicleModel, VehicleModelFilteringRequestParameters>(RequestParameters),
    IRequest<Result<PaginationResult<ModelDto>>>;