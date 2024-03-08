using Domain.Entities.VehicleRelated.Classes.Common.Classes;
using Domain.Entities.VehicleRelated.Classes.TypesRelated;

namespace Domain.Entities.VehicleRelated.Classes;

public sealed class VehicleModel : NamedVehicleAspect
{
    public int MinimalProductionYear { get; init; }
    public int MaximumProductionYear { get; init; }
    public VehicleBrand Brand { get; set; } = null!;
    public ICollection<VehicleType> AvailableTypes { get; init; } = [];
    public ICollection<VehicleEngineType> AvailableEngineTypes { get; init; } = [];
    public ICollection<VehicleTransmissionType> AvailableTransmissionTypes { get; init; } = [];
    public ICollection<VehicleDrivetrainType> AvailableDrivetrainTypes { get; init; } = [];
    public ICollection<VehicleBodyType> AvailableBodyTypes { get; init; } = [];
    
    public VehicleModel() { }

    public VehicleModel(VehicleBrand brand, string name, ICollection<VehicleType> availableTypes) : base(name)
    {
        Brand = brand;
        AvailableTypes = availableTypes;
    }

    public VehicleModel(VehicleBrand brand, string name, IEnumerable<Guid> availableTypesIds) : base(name)
    {
        Brand = brand;
        AvailableTypes = availableTypesIds.Select(id => new VehicleType { Id = id }).ToList();
    }
}