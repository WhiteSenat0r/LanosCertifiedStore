using Application.Queries.Vehicles.ListVehicles;

namespace UnitTests.Application.Queries.VehicleRelated;

public class ListVehicleQueryTests
{
    [Fact]
    public void Constructor_InstantiatesNewQuery()
    {
        // Arrange & Act
        var result = new ListVehiclesQuery(new VehicleRequestParameters());
        
        // Assert
        Assert.NotNull(result);
    }
}