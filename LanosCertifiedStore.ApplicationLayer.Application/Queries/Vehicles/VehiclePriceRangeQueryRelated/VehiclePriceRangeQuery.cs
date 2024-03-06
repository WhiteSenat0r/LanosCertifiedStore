using Application.RequestParams;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Vehicles.VehiclePriceRangeQueryRelated;

public sealed record VehiclePriceRangeQuery(VehicleFilteringRequestParameters RequestParameters) : 
    IRequest<Result<IDictionary<string, decimal>>>;