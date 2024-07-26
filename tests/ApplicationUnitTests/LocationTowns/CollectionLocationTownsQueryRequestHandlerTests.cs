using LanosCertifiedStore.Application.LocationTowns;
using LanosCertifiedStore.Application.LocationTowns.Dtos;
using LanosCertifiedStore.Application.LocationTowns.Queries.LocationTownsRelated.CollectionLocationTownsQueryRequestRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;

namespace ApplicationUnitTests.LocationTowns;

public sealed class CollectionLocationTownsQueryRequestHandlerTests
{
    private readonly ILocationTownService _locationTownService = Substitute.For<ILocationTownService>();
    private readonly CollectionLocationTownsQueryRequestHandler _handler;

    private readonly CollectionLocationTownsQueryRequest _request =
        new(new VehicleLocationTownFilteringRequestParameters());

    public CollectionLocationTownsQueryRequestHandlerTests()
    {
        _handler = new CollectionLocationTownsQueryRequestHandler(_locationTownService);
    }

    [Fact]
    public async Task Handler_ShouldInvokeGetLocationTownCollection_FromLocationTownService()
    {
        // Act
        await _handler.Handle(_request, default);

        // Assert
        await _locationTownService
            .Received()
            .GetLocationTownCollection(_request, default!);
    }

    [Fact]
    public async Task Handler_ShouldReturnCollectionOfLocationTowns()
    {
        // Arrange
        List<LocationTownDto> expectedTowns =
        [
            new LocationTownDto { Id = Guid.NewGuid(), Name = "Унгвар" },
            new LocationTownDto { Id = Guid.NewGuid(), Name = "Бударьпешт" },
            new LocationTownDto { Id = Guid.NewGuid(), Name = "Бєлгород" }
        ];

        var expectedResult = new PaginationResult<LocationTownDto>(
            expectedTowns,
            _request.FilteringParameters.PageIndex);

        _locationTownService.GetLocationTownCollection(_request, default)
            .Returns(expectedTowns);

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