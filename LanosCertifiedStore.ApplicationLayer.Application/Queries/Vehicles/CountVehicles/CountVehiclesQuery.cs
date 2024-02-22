﻿using Application.Dtos.Common;
using Application.RequestParams;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Vehicles.CountVehicles;

public record CountVehiclesQuery(VehicleFilteringRequestParameters RequestParameters) : IRequest<Result<ItemsCountDto>>;