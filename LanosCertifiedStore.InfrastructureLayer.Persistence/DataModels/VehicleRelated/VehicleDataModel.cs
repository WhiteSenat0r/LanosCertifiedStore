using Domain.Contracts.Common;
using Persistence.DataModels.VehicleRelated.LocationRelated;
using Persistence.DataModels.VehicleRelated.TypeRelated;

namespace Persistence.DataModels.VehicleRelated;

internal sealed class VehicleDataModel : IIdentifiable<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Description { get; set; } = null!;
    public double Displacement { get; set; }
    public int Mileage { get; set; }
    public int ProductionYear { get; set; }
    public Guid LocationTownId { get; set; }
    public VehicleLocationTownDataModel LocationTown { get; set; } = null!;
    public Guid BrandId { get; set; }
    public VehicleBrandDataModel Brand { get; set; } = null!;
    public Guid ModelId { get; set; }
    public VehicleModelDataModel Model { get; set; } = null!;
    public Guid ColorId { get; set; }
    public VehicleColorDataModel Color { get; set; } = null!;
    public Guid VehicleTypeId { get; set; }
    public VehicleTypeDataModel VehicleType { get; set; } = null!;
    public Guid BodyTypeId { get; set; }
    public VehicleBodyTypeDataModel BodyType { get; set; } = null!;
    public Guid EngineTypeId { get; set; }
    public VehicleEngineTypeDataModel EngineType { get; set; } = null!;
    public Guid TransmissionTypeId { get; set; }
    public VehicleTransmissionTypeDataModel TransmissionType { get; set; } = null!;
    public Guid DrivetrainTypeId { get; set; }
    public VehicleDrivetrainTypeDataModel DrivetrainType { get; set; } = null!;
    public ICollection<VehicleImageDataModel> Images { get; set; } = new List<VehicleImageDataModel>();
    public ICollection<VehiclePriceDataModel> Prices { get; set; } = new List<VehiclePriceDataModel>();

    public VehicleDataModel() { }
    
    public VehicleDataModel(
        Guid brandId,
        Guid modelId,
        Guid vehicleTypeId,
        Guid colorId,
        decimal price,
        double displacement,
        string description)
    {
        BrandId = brandId;
        ModelId = modelId;
        VehicleTypeId = vehicleTypeId;
        ColorId = colorId;
        Displacement = displacement;
        Prices.Add(new VehiclePriceDataModel(Id, price));
        Description = description;
    }
}
