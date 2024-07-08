using Application.Dtos.Common;
using Application.Dtos.ModelDtos;

namespace Application.Dtos.BrandDtos;

public sealed record SingleVehicleBrandDto(IEnumerable<VehicleModelWithoutBrandNameDto>? Models) : VehicleAspectDto;