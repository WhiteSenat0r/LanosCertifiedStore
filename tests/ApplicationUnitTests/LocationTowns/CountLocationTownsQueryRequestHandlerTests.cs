using Application.LocationTowns;
using Application.LocationTowns.Queries.LocationTownsRelated.CountLocationTownsQueryRelated;
using Application.Shared.DtosRelated;

namespace ApplicationUnitTests.LocationTowns;

public sealed class CountLocationTownsQueryRequestHandlerTests
{
    private readonly ILocationTownService _locationTownService = Substitute.For<ILocationTownService>();
    private readonly CountLocationTownsQueryRequestHandler _handler;
    private readonly CountLocationTownsQueryRequest _request = new(new VehicleLocationTownFilteringRequestParameters());

    public CountLocationTownsQueryRequestHandlerTests()
    {
        _handler = new CountLocationTownsQueryRequestHandler(_locationTownService);
    }

    [Fact]
    public async Task Handler_ShouldInvokeGetLocationTownsCount_FromLocationTownService()
    {
        // Act
        await _handler.Handle(_request, default);

        // Assert
        await _locationTownService
            .Received()
            .GetLocationTownsCount(_request, default!);
    }

    [Fact]
    public async Task Handler_ShouldReturnCountOfLocationTowns()
    {
        // Arrange
        var locationTownsCount = new ItemsCountDto(3, 3);

        _locationTownService.GetLocationTownsCount(_request, default)
            .Returns(locationTownsCount);

        // Act
        var result = await _handler.Handle(_request, default);

        // Assert
        result.IsSuccess
            .Should().BeTrue();

        result.Value
            .Should()
            .Be(locationTownsCount);
    }
}