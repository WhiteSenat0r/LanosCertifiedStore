using Application.Shared.DtosRelated;
using Application.VehicleModels.Dtos;

namespace Application.VehicleBrands.Dtos;

public sealed record SingleVehicleBrandDto(IEnumerable<VehicleModelWithoutBrandNameDto>? Models) : VehicleAspectDto;