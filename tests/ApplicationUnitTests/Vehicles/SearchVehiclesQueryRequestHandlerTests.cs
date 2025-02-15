using LanosCertifiedStore.Application.Vehicles;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using LanosCertifiedStore.Application.Vehicles.Queries.SearchVehiclesQueryRelated;

namespace ApplicationUnitTests.Vehicles;

public sealed class SearchVehiclesQueryRequestHandlerTests
{
    private readonly IVehicleService _vehicleService = Substitute.For<IVehicleService>();
    private readonly SearchVehiclesQueryRequestHandler _handler;
    private readonly SearchVehiclesQueryRequest _request = new(new VehicleFilteringRequestParameters());

    public SearchVehiclesQueryRequestHandlerTests()
    {
        _handler = new SearchVehiclesQueryRequestHandler(_vehicleService);
    }
    
    [Fact]
    public async Task Handle_WhenRequestIsValid_ShouldReturnPaginatedVehicles()
    {
        // Arrange
        var vehicles = new List<SearchVehicleDto>
        {
            new() { Id = Guid.NewGuid() },
            new() { Id = Guid.NewGuid() }
        };

        _vehicleService.FindRelevantVehicles(_request, Arg.Any<CancellationToken>())
            .Returns(vehicles);

        // Act
        var result = await _handler.Handle(_request, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Value.Items.Should().BeEquivalentTo(vehicles);
        result.Value.PageIndex.Should().Be(_request.FilteringParameters.PageIndex);
    }
}