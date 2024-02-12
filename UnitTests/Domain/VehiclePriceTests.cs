using Domain.Entities.VehicleRelated.Classes;

namespace UnitTests.Domain;

public class VehiclePriceTests
{
    [Fact]
    public void ConstructorWithValue_SetsValue()
    {
        // Arrange
        var value = 2.5m;

        // Act
        var price = new VehiclePrice(Guid.Empty, value);

        // Assert
        Assert.Equal(value, price.Value);
    }

    [Fact]
    public void DefaultConstructor_SetsDefaultValue()
    {
        // Arrange & Act
        var price = new VehiclePrice();

        // Assert
        Assert.Equal(0m, price.Value);
    }
    
    [Fact]
    public void Id_ValueHasToBeAbleToSetNewData()
    {
        // Arrange & Act
        var price = new VehiclePrice
        {
            Id = Guid.Empty
        };

        // Assert
        Assert.Equal(Guid.Empty, price.Id);
    }

    [Fact]
    public void VehicleValue_CanBeReceivedAndAssigned()
    {
        // Arrange
        var vehicle = new Vehicle();
        
        // Act
        var price = new VehiclePrice
        {
            Vehicle = vehicle,
            VehicleId = vehicle.Id
        };

        // Assert
        Assert.Equal(vehicle, price.Vehicle);
        Assert.Equal(vehicle.Id, price.VehicleId);
    }
    
    [Fact]
    public void IssueDate_CanBeReceivedAndAssigned()
    {
        // Arrange
        var price = new VehiclePrice(Guid.Empty, 0m);
        var changedDate = DateTime.UtcNow;
        
        // Act
        if (changedDate != price.IssueDate) price.IssueDate = changedDate;

        // Assert
        Assert.Equal(changedDate, price.IssueDate);
    }
}