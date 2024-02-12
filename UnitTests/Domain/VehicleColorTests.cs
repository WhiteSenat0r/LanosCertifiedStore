using Domain.Entities.VehicleRelated.Classes;

namespace UnitTests.Domain;


public class VehicleColorTests
{
    [Fact]
    public void ConstructorWithName_SetsName()
    {
        // Arrange
        var colorName = "Red";

        // Act
        var color = new VehicleColor(colorName);

        // Assert
        Assert.Equal(colorName, color.Name);
    }

    [Fact]
    public void DefaultConstructor_SetsEmptyName()
    {
        // Arrange & Act
        var color = new VehicleColor();

        // Assert
        Assert.Null(color.Name);
    }

    [Fact]
    public void VehicleCollectionValue_CanBeReceivedAndAssigned()
    {
        // Arrange
        var color = new VehicleColor
        {
            Vehicles = new List<Vehicle>
            {
                new(), new(), new()
            }
        };

        // Assert
        Assert.NotEmpty(color.Vehicles);
    }
}