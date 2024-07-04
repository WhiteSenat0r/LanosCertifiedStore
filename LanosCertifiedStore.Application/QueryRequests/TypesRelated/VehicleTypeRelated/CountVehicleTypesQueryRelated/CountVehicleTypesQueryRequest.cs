using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestRelated.QueryRelated;
using Domain.Entities.VehicleRelated.TypeRelated;

namespace Application.QueryRequests.TypesRelated.VehicleTypeRelated.CountVehicleTypesQueryRelated;

public sealed record CountVehicleTypesQueryRequest(IFilteringRequestParameters<VehicleType> FilteringParameters) : 
    ICountQueryRequest<VehicleType>;