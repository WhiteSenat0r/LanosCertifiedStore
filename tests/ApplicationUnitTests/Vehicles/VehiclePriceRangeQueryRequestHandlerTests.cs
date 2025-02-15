using LanosCertifiedStore.Application.Vehicles;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using LanosCertifiedStore.Application.Vehicles.Queries.VehiclePriceRangeQueryRelated;

namespace ApplicationUnitTests.Vehicles;

public sealed class VehiclePriceRangeQueryRequestHandlerTests
{
    private readonly IVehicleService _vehicleService = Substitute.For<IVehicleService>();
    private readonly VehiclePriceRangeQueryRequestHandler _handler;
    private readonly VehiclePriceRangeQueryRequest _request = new(new VehicleFilteringRequestParameters());

    public VehiclePriceRangeQueryRequestHandlerTests()
    {
        _handler = new VehiclePriceRangeQueryRequestHandler(_vehicleService);
    }
    
    [Fact]
    public async Task Handle_WhenRequestIsValid_ShouldReturnPriceRange()
    {
        // Arrange
        var priceRange = new PriceRangeDto
        {
            Lowest = 1000,
            Highest = 5000
        };

        _vehicleService.GetPriceRange(_request, Arg.Any<CancellationToken>())
            .Returns(priceRange);

        // Act
        var result = await _handler.Handle(_request, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Value.Lowest.Should().Be(priceRange.Lowest);
        result.Value.Highest.Should().Be(priceRange.Highest);
    }
}