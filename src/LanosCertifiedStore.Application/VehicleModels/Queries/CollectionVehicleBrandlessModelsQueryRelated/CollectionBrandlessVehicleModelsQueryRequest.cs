using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.VehicleModels.Dtos;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;

namespace LanosCertifiedStore.Application.VehicleModels.Queries.CollectionVehicleBrandlessModelsQueryRelated;

public sealed record CollectionBrandlessVehicleModelsQueryRequest(
    IFilteringRequestParameters<VehicleModel> FilteringParameters) : 
    ICollectionQueryRequest<VehicleModel, PaginationResult<VehicleModelWithoutBrandNameDto>, VehicleModelWithoutBrandNameDto>;