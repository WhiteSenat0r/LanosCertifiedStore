using Application.Contracts.Common;
using Application.Contracts.RequestRelated.QueryRelated;
using Domain.Entities.VehicleRelated.TypeRelated;

namespace Application.QueryRequests.TypesRelated.VehicleBodyTypeRelated.CountVehicleBodyTypesQueryRelated;

public sealed record CountVehicleBodyTypesQueryRequest(IFilteringRequestParameters<VehicleBodyType> FilteringParameters)
    : ICountQueryRequest<VehicleBodyType>;