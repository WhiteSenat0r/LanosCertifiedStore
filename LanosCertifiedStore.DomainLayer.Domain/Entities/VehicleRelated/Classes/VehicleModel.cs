using Domain.Entities.VehicleRelated.Classes.Common.Classes;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;

namespace Domain.Entities.VehicleRelated.Classes;

public sealed class VehicleModel : NamedVehicleAspect
{
    public int MinimalProductionYear { get; set; }
    public int? MaximumProductionYear { get; set; }
    public VehicleBrand Brand { get; set; } = null!;
    public VehicleType VehicleType { get; set; } = null!;
    public ICollection<VehicleEngineType> AvailableEngineTypes { get; set; } = [];
    public ICollection<VehicleTransmissionType> AvailableTransmissionTypes { get; set; } = [];
    public ICollection<VehicleDrivetrainType> AvailableDrivetrainTypes { get; set; } = [];
    public ICollection<VehicleBodyType> AvailableBodyTypes { get; set; } = [];
    
    public VehicleModel() { }

    public VehicleModel(
        VehicleBrand brand,
        VehicleType type,
        string name,
        IEnumerable<Guid> availableEngineTypeIds,
        IEnumerable<Guid> availableTransmissionTypeIds,
        IEnumerable<Guid> availableDrivetrainTypeIds,
        IEnumerable<Guid> availableBodyTypeIds,
        int minimalProductionYear,
        int? maximumProductionYear = null) : base(name)
    {
        Brand = brand;
        VehicleType = type;
        MinimalProductionYear = minimalProductionYear;
        MaximumProductionYear = maximumProductionYear;
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