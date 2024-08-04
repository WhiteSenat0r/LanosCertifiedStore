using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using MediatR;

namespace LanosCertifiedStore.Application.Vehicles.Queries.VehiclePriceRangeQueryRelated;

public sealed record VehiclePriceRangeQueryRequest(VehicleFilteringRequestParameters RequestParameters) :
    IRequest<Result<PriceRangeDto>>;