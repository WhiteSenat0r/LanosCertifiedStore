using LanosCertifiedStore.Application.Identity;
using LanosCertifiedStore.Application.Vehicles;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using LanosCertifiedStore.Application.Vehicles.Queries.CollectionVehiclesQueryRelated;

namespace ApplicationUnitTests.Vehicles;

public sealed class CollectionVehiclesQueryRequestHandlerTests
{
    private readonly IVehicleService _vehicleService = Substitute.For<IVehicleService>();
    private readonly IUserContext _userContext = Substitute.For<IUserContext>();
    private readonly CollectionVehiclesQueryRequestHandler _handler;
    private readonly CollectionVehiclesQueryRequest _request = new(new VehicleFilteringRequestParameters());

    public CollectionVehiclesQueryRequestHandlerTests()
    {
        _handler = new CollectionVehiclesQueryRequestHandler(_vehicleService, _userContext);
    }
    
    [Fact]
    public async Task Handle_WhenRequestIsValid_ShouldReturnPaginatedVehicles()
    {
        // Arrange
        var vehicles = new List<VehicleDto>
        {
            new() { Id = Guid.NewGuid(), Mileage = 50000, Displacement = 2.0, Price = 25000.0m },
            new() { Id = Guid.NewGuid(), Mileage = 30000, Displacement = 1.6, Price = 18000.0m }
        };

        _vehicleService.GetVehicles(_request, Arg.Any<CancellationToken>())
            .Returns(vehicles);

        // Act
        var result = await _handler.Handle(_request, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Value.Items.Should().BeEquivalentTo(vehicles);
        result.Value.PageIndex.Should().Be(_request.FilteringParameters.PageIndex);
    }
}