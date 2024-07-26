using LanosCertifiedStore.Application.Shared.DtosRelated;
using LanosCertifiedStore.Application.VehicleModels.Dtos;

namespace LanosCertifiedStore.Application.VehicleBrands.Dtos;

public sealed record SingleVehicleBrandDto(IEnumerable<VehicleModelWithoutBrandNameDto>? Models) : VehicleAspectDto;