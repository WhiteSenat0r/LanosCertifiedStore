using Domain.Entities.VehicleRelated.Classes.Common.Classes;
using Domain.Entities.VehicleRelated.Classes.TypesRelated;

namespace Domain.Entities.VehicleRelated.Classes;

public sealed class VehicleModel : NamedVehicleAspect
{
    public int MinimalProductionYear { get; init; }
    public int? MaximumProductionYear { get; init; }
    public VehicleBrand Brand { get; set; } = null!;
    public ICollection<VehicleType> AvailableTypes { get; init; } = [];
    public ICollection<VehicleEngineType> AvailableEngineTypes { get; init; } = [];
    public ICollection<VehicleTransmissionType> AvailableTransmissionTypes { get; init; } = [];
    public ICollection<VehicleDrivetrainType> AvailableDrivetrainTypes { get; init; } = [];
    public ICollection<VehicleBodyType> AvailableBodyTypes { get; init; } = [];
    
    public VehicleModel() { }

    public VehicleModel(
        VehicleBrand brand,
        string name,
        IEnumerable<Guid> availableTypesIds,
        IEnumerable<Guid> availableEngineTypeIds,
        IEnumerable<Guid> availableTransmissionTypeIds,
        IEnumerable<Guid> availableDrivetrainTypeIds,
        IEnumerable<Guid> availableBodyTypeIds,
        int minimalProductionYear,
        int? maximumProductionYear = null) : base(name)
    {
        Brand = brand;
        MinimalProductionYear = minimalProductionYear;
        MaximumProductionYear = maximumProductionYear;
        AvailableTypes = availableTypesIds.Select(
            id => new VehicleType { Id = id }).ToList();
        AvailableEngineTypes = availableEngineTypeIds.Select(
            id => new VehicleEngineType { Id = id }).ToList();
        AvailableTransmissionTypes = availableTransmissionTypeIds.Select(
            id => new VehicleTransmissionType { Id = id }).ToList();
        AvailableDrivetrainTypes = availableDrivetrainTypeIds.Select(
            id => new VehicleDrivetrainType { Id = id }).ToList();
        AvailableBodyTypes = availableBodyTypeIds.Select(
            id => new VehicleBodyType { Id = id }).ToList();
    }
}