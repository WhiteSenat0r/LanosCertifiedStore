using Domain.Entities.VehicleRelated.Classes;

namespace UnitTests.Domain;


public class VehicleModelTests
{
    [Fact]
    public void ConstructorWithNameAndBrandId_SetsNameAndBrandId()
    {
        // Arrange
        var modelName = "Camry";

        // Act
        var model = new VehicleModel(Guid.Empty, modelName);

        // Assert
        Assert.Equal(modelName, model.Name);
        Assert.Equal(Guid.Empty, model.VehicleBrandId);
    }

    [Fact]
    public void DefaultConstructor_SetsEmptyNameAndEmptyVehicleId()
    {
        // Arrange & Act
        var model = new VehicleModel();

        // Assert
        Assert.Null(model.Name);
        Assert.Equal(Guid.Empty, model.VehicleBrandId);
    }

    [Fact]
    public void AddBrand_AddsBrandToModel()
    {
        // Arrange & Act
        var brand = new VehicleBrand("Toyota");
        var model = new VehicleModel(brand.Id, "Camry")
        {
            VehicleBrand = brand
        };

        // Assert
        Assert.Equal(brand, model.VehicleBrand);
    }
}