﻿using Application.Shared.ResultRelated;
using MediatR;

namespace Application.Vehicles.Queries.VehiclePriceRangeQueryRelated;

public sealed record VehiclePriceRangeQuery(VehicleFilteringRequestParameters RequestParameters) : 
    IRequest<Result<IDictionary<string, decimal>>>;