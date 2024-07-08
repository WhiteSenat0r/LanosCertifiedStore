using Application.Shared.RequestParamsRelated;
using Application.Shared.RequestRelated.QueryRelated;
using Application.Shared.ResultRelated;
using Domain.Entities.VehicleRelated;

namespace Application.VehicleColors.Queries.CollectionVehicleColorsQueryRequestRelated;

public sealed record CollectionVehicleColorsQueryRequest(
    IFilteringRequestParameters<VehicleColor> FilteringParameters) :
    ICollectionQueryRequest<VehicleColor, PaginationResult<VehicleColorDto>, VehicleColorDto>;