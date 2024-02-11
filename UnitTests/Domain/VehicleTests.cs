using Domain.Entities.VehicleRelated.Classes;

namespace UnitTests.Domain;

public class VehicleTests
{
    [Fact]
    public void Constructor_SetsProperties()
    {
        // Arrange
        var brandId = Guid.NewGuid();
        var modelId = Guid.NewGuid();
        var typeId = Guid.NewGuid();
        var colorId = Guid.NewGuid();
        var displacementId = Guid.NewGuid();
        var price = 50000.00m;
        var description = "Test vehicle";

        // Act
        var vehicle = new Vehicle(brandId, modelId, typeId, colorId, displacementId, price, description);

        // Assert
        Assert.Equal(brandId, vehicle.BrandId);
        Assert.Equal(modelId, vehicle.ModelId);
        Assert.Equal(typeId, vehicle.TypeId);
        Assert.Equal(colorId, vehicle.ColorId);
        Assert.Equal(displacementId, vehicle.DisplacementId);
        Assert.Single(vehicle.Prices);
        Assert.Equal(price, vehicle.Prices.ElementAt(0).Value);
        Assert.Equal(description, vehicle.Description);
    }

    [Fact]
    public void DefaultConstructor_SetsProperties()
    {
        // Arrange & Act
        var vehicle = new Vehicle();

        // Assert
        Assert.NotEqual(Guid.Empty, vehicle.Id);
        Assert.Null(vehicle.Description);
        Assert.Equal(Guid.Empty, vehicle.BrandId);
        Assert.Null(vehicle.Brand);
        Assert.Equal(Guid.Empty, vehicle.ModelId);
        Assert.Null(vehicle.Model);
        Assert.Equal(Guid.Empty, vehicle.ColorId);
        Assert.Null(vehicle.Color);
        Assert.Equal(Guid.Empty, vehicle.TypeId);
        Assert.Null(vehicle.Type);
        Assert.Equal(Guid.Empty, vehicle.DisplacementId);
        Assert.Null(vehicle.Displacement);
        Assert.NotNull(vehicle.Prices);
        Assert.Empty(vehicle.Prices);
    }
    
    [Fact]
    public void VehicleRelatedAspects_CanBeReceivedAndAssigned()
    {
        // Arrange & Act
        var vehicle = new Vehicle
        {
            Id = Guid.NewGuid(),
            Brand = new VehicleBrand(),
            Color = new VehicleColor(),
            Type = new VehicleType(),
            Displacement = new VehicleDisplacement(),
            Model = new VehicleModel(),
            Prices = new List<VehiclePrice>()
        };

        // Assert
        Assert.NotNull(vehicle.Brand);
        Assert.NotNull(vehicle.Model);
        Assert.NotNull(vehicle.Color);
        Assert.NotNull(vehicle.Type);
        Assert.NotNull(vehicle.Displacement);
        Assert.Empty(vehicle.Prices);
    }

    [Fact]
    public void AddPrice_AddsPriceToPricesCollection()
    {
        // Arrange
        var vehicle = new Vehicle();
        var price = new VehiclePrice(Guid.NewGuid(), 45000.00m);

        // Act
        vehicle.Prices.Add(price);

        // Assert
        Assert.Contains(price, vehicle.Prices);
    }

    [Fact]
    public void RemovePrice_RemovesPriceFromPricesCollection()
    {
        // Arrange
        var vehicle = new Vehicle();
        var price = new VehiclePrice(Guid.NewGuid(), 45000.00m);
        vehicle.Prices.Add(price);

        // Act
        vehicle.Prices.Remove(price);

        // Assert
        Assert.DoesNotContain(price, vehicle.Prices);
    }
}