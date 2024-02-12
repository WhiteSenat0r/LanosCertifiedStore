using Domain.Entities.VehicleRelated.Classes;

namespace UnitTests.Domain;


public class VehicleDisplacementTests
{
    [Fact]
    public void ConstructorWithValue_SetsValue()
    {
        // Arrange
        var value = 2.5d;

        // Act
        var displacement = new VehicleDisplacement(value);

        // Assert
        Assert.Equal(value, displacement.Value);
    }

    [Fact]
    public void DefaultConstructor_SetsDefaultValue()
    {
        // Arrange & Act
        var displacement = new VehicleDisplacement();

        // Assert
        Assert.Equal(0d, displacement.Value);
    }
    
    [Fact]
    public void Id_ValueHasToBeAbleToSetNewData()
    {
        // Arrange & Act
        var displacement = new VehicleDisplacement
        {
            Id = Guid.Empty
        };

        // Assert
        Assert.Equal(Guid.Empty, displacement.Id);
    }

    [Fact]
    public void VehicleCollectionValue_CanBeReceivedAndAssigned()
    {
        // Arrange
        var displacement = new VehicleDisplacement
        {
            Vehicles = new List<Vehicle>
            {
                new(), new(), new()
            }
        };

        // Assert
        Assert.NotEmpty(displacement.Vehicles);
    }
}