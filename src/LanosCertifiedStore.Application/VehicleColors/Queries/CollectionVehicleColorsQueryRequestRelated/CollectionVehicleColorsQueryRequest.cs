using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;

namespace LanosCertifiedStore.Application.VehicleColors.Queries.CollectionVehicleColorsQueryRequestRelated;

public sealed record CollectionVehicleColorsQueryRequest(
    IFilteringRequestParameters<VehicleColor> FilteringParameters) :
    ICollectionQueryRequest<VehicleColor, PaginationResult<VehicleColorDto>, VehicleColorDto>;