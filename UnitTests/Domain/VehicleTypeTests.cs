using Domain.Entities.VehicleRelated.Classes;

namespace UnitTests.Domain;


public class VehicleTypeTests
{
    [Fact]
    public void ConstructorWithName_SetsName()
    {
        // Arrange
        var typeName = "Wagon";

        // Act
        var type = new VehicleType(typeName);

        // Assert
        Assert.Equal(typeName, type.Name);
    }

    [Fact]
    public void DefaultConstructor_SetsEmptyName()
    {
        // Arrange & Act
        var type = new VehicleType();

        // Assert
        Assert.Null(type.Name);
    }

    [Fact]
    public void VehicleCollectionValue_CanBeReceivedAndAssigned()
    {
        // Arrange
        var type = new VehicleType
        {
            Vehicles = new List<Vehicle>
            {
                new(), new(), new()
            }
        };

        // Assert
        Assert.NotEmpty(type.Vehicles);
    }
}