using Application.LocationRegions;
using Application.LocationRegions.Dtos;
using Application.LocationRegions.Queries.CollectionLocationRegionsQueryRequestRelated;
using Application.Shared.ResultRelated;

namespace ApplicationUnitTests.LocationRegions;

public sealed class CollectionLocationTownsQueryRequestHandlerTests
{
    private readonly ILocationRegionService _locationRegionService = Substitute.For<ILocationRegionService>();
    private readonly CollectionLocationTownsQueryRequestHandler _handler;
    private readonly CollectionLocationRegionsQueryRequest _request = new(new VehicleLocationRegionFilteringRequestParameters());

    public CollectionLocationTownsQueryRequestHandlerTests()
    {
        _handler = new CollectionLocationTownsQueryRequestHandler(_locationRegionService);
    }

    [Fact]
    public async Task Handler_ShouldInvokeGetLocationRegionCollection_FromLocationRegionService()
    {
        // Act
        await _handler.Handle(_request, default);

        // Assert
        await _locationRegionService
            .Received()
            .GetLocationRegionCollection(_request, default!);
    }

    [Fact]
    public async Task Handler_ShouldReturnCollectionOfLocationRegions()
    {
        // Arrange
        List<LocationRegionDto> expectedRegions =
        [
            new LocationRegionDto { Id = Guid.NewGuid(), Name = "Рівненська область" },
            new LocationRegionDto { Id = Guid.NewGuid(), Name = "Закарпатська область" },
            new LocationRegionDto { Id = Guid.NewGuid(), Name = "БНР" }
        ];

        var expectedResult = new PaginationResult<LocationRegionDto>(
            expectedRegions,
            _request.FilteringParameters.PageIndex);

        _locationRegionService.GetLocationRegionCollection(_request, default)
            .Returns(expectedRegions);

        // Act
        var result = await _handler.Handle(_request, default);

        // Assert
        result.IsSuccess
            .Should().BeTrue();

        result.Value
            .Should()
            .BeEquivalentTo(expectedResult);
    }
}