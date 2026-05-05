using LanosCertifiedStore.Application.Shared.Dtos.CountItemsRelated;
using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Application.Shared.RequestParamsRelated.RequestBases;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using MediatR;

namespace LanosCertifiedStore.Application.Vehicles.Queries.CountVehiclesQueryRelated;

public sealed record CountVehiclesQueryRequest(IFilteringRequestParameters<Vehicle> RequestParameters) :
    CountItemsQueryRequestBase<Vehicle>(RequestParameters), IRequest<Result<ItemsCountDto>>;