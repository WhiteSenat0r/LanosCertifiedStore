using Application.RequestParameters;
using Application.Shared.ResultRelated;
using MediatR;

namespace Application.QueryRequests.Vehicles.VehiclePriceRangeQueryRelated;

public sealed record VehiclePriceRangeQuery(VehicleFilteringRequestParameters RequestParameters) : 
    IRequest<Result<IDictionary<string, decimal>>>;