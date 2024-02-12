using Application.Queries.Vehicles.VehicleDetails;

namespace UnitTests.Application.Queries.VehicleRelated;

public class VehicleDetailsQueryTests
{
    [Fact]
    public void Constructor_InstantiatesNewQuery()
    {
        // Arrange & Act
        var result = new VehicleDetailsQuery(Guid.Empty);
        
        // Assert
        Assert.NotNull(result);
    }
}