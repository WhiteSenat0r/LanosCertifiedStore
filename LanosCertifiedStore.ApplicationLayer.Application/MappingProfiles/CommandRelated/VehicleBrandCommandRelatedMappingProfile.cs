using Application.Commands.Brands.UpdateBrand;
using AutoMapper;
using Domain.Models.VehicleRelated.Classes;

namespace Application.MappingProfiles.CommandRelated;

public sealed class VehicleBrandCommandRelatedMappingProfile : Profile
{
    public VehicleBrandCommandRelatedMappingProfile()
    {
        GetUpdateVehicleBrandCommandInstanceMapping();
    }

    private void GetUpdateVehicleBrandCommandInstanceMapping()
    {
        CreateMap<UpdateBrandCommand, VehicleBrand>().ForMember(c => c.Name, m => m.MapFrom(b => b.UpdatedName));
    }
}