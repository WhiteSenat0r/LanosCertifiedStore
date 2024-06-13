using AutoMapper;
using Domain.Models.VehicleRelated.Classes.Common.Classes;

namespace Persistence.MappingHelpers.VehicleRelated.LocationRelated.Common.Classes;

public abstract class LocationRelatedMappingProfileBase : Profile
{
    private protected ICollection<T> MapObjectRange<T>(IEnumerable<T> objects)
        where T : NamedVehicleAspect, new() => 
        objects.Select(t => new T { Id = t.Id }).ToList();
}