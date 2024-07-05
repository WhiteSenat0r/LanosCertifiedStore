using Application.Contracts.Common;
using Application.Contracts.RequestRelated.QueryRelated;
using Application.Core.Results;
using Application.Dtos.ColorDtos;
using Domain.Entities.VehicleRelated;

namespace Application.QueryRequests.VehicleColorsRelated.CollectionVehicleColorsQueryRequestRelated;

public sealed record CollectionVehicleColorsQueryRequest(
    IFilteringRequestParameters<VehicleColor> FilteringParameters) :
    ICollectionQueryRequest<VehicleColor, PaginationResult<VehicleColorDto>, VehicleColorDto>;