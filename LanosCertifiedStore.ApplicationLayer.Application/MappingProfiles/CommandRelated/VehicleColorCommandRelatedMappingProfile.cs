using Application.Commands.Colors.UpdateColor;
using AutoMapper;
using Domain.Models.VehicleRelated.Classes;

namespace Application.MappingProfiles.CommandRelated;

public sealed class VehicleColorCommandRelatedMappingProfile : Profile
{
    public VehicleColorCommandRelatedMappingProfile()
    {
        GetUpdateVehicleColorCommandInstanceMapping();
    }

    private void GetUpdateVehicleColorCommandInstanceMapping()
    {
        CreateMap<UpdateColorCommand, VehicleColor>()
            .ForMember(c => c.Name,
                opts => opts.Condition((c, m) => 
                    !string.IsNullOrEmpty(c.UpdatedName) &&
                    string.IsNullOrWhiteSpace(c.UpdatedName) &&
                    !c.UpdatedName.Equals(m.Name)))
            .ForMember(c => c.HexValue,
                opts => opts.Condition((c, m) => 
                    !string.IsNullOrEmpty(c.UpdatedHexValue) &&
                    string.IsNullOrWhiteSpace(c.UpdatedHexValue) &&
                    !c.UpdatedHexValue.Equals(m.HexValue)));
    }
}