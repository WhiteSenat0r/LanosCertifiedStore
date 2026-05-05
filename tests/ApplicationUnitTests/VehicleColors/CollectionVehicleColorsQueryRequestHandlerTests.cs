using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.VehicleColors;
using LanosCertifiedStore.Application.VehicleColors.Queries.CollectionVehicleColorsQueryRequestRelated;

namespace ApplicationUnitTests.VehicleColors;

public sealed class CollectionVehicleColorsQueryRequestHandlerTests
{
    private readonly IVehicleColorService _vehicleColorService = Substitute.For<IVehicleColorService>();
    private readonly CollectionVehicleColorsQueryRequestHandler _handler;
    private readonly CollectionVehicleColorsQueryRequest _request = new(new VehicleColorFilteringRequestParameters());

    public CollectionVehicleColorsQueryRequestHandlerTests()
    {
        _handler = new CollectionVehicleColorsQueryRequestHandler(_vehicleColorService);
    }

    [Fact]
    public async Task Handler_ShouldInvokeGetVehicleColorCollection_FromVehicleColorService()
    {
        // Act
        await _handler.Handle(_request, default);

        // Assert
        await _vehicleColorService
            .Received()
            .GetVehicleColorCollection(_request, default!);
    }

    [Fact]
    public async Task Handler_ShouldReturnCollectionOfVehicleColors()
    {
        // Arrange
        List<VehicleColorDto> expectedColors =
        [
            new VehicleColorDto("#FFFFFF") { Id = Guid.NewGuid(), Name = "Білий" },
            new VehicleColorDto("#000000") { Id = Guid.NewGuid(), Name = "Чорний" },
            new VehicleColorDto("#FF0000") { Id = Guid.NewGuid(), Name = "Червоний" }
        ];

        var expectedResult = new PaginationResult<VehicleColorDto>(
            expectedColors,
            _request.FilteringParameters.PageIndex);

        _vehicleColorService.GetVehicleColorCollection(_request, default)
            .Returns(expectedColors);

        // Act
        var result = await _handler.Handle(_request, default);

        // Assert
        result.IsSuccess
            .Should().BeTrue();

        result.Value
            .Should()
            .BeEquivalentTo(expectedResult);
    }

    [Fact]
    public async Task Handler_ShouldReturnEmptyCollection_WhenNoColorsExist()
    {
        // Arrange
        List<VehicleColorDto> emptyColors = [];

        var expectedResult = new PaginationResult<VehicleColorDto>(
            emptyColors,
            _request.FilteringParameters.PageIndex);

        _vehicleColorService.GetVehicleColorCollection(_request, default)
            .Returns(emptyColors);

        // Act
        var result = await _handler.Handle(_request, default);

        // Assert
        result.IsSuccess
            .Should().BeTrue();

        result.Value
            .Should()
            .BeEquivalentTo(expectedResult);

        result.Value!.Items
            .Should()
            .BeEmpty();
    }

    [Fact]
    public async Task Handler_ShouldReturnSingleColor_WhenOnlyOneColorExists()
    {
        // Arrange
        List<VehicleColorDto> singleColor =
        [
            new VehicleColorDto("#0000FF") { Id = Guid.NewGuid(), Name = "Синій" }
        ];

        var expectedResult = new PaginationResult<VehicleColorDto>(
            singleColor,
            _request.FilteringParameters.PageIndex);

        _vehicleColorService.GetVehicleColorCollection(_request, default)
            .Returns(singleColor);

        // Act
        var result = await _handler.Handle(_request, default);

        // Assert
        result.IsSuccess
            .Should().BeTrue();

        result.Value!.Items
            .Should()
            .HaveCount(1);

        result.Value.Items.First().Name
            .Should()
            .Be("Синій");
    }

    [Fact]
    public async Task Handler_ShouldPassCorrectFilteringParameters_ToService()
    {
        // Arrange
        var customFilteringParams = new VehicleColorFilteringRequestParameters
        {
            PageIndex = 2,
            PageSize = 10
        };
        var customRequest = new CollectionVehicleColorsQueryRequest(customFilteringParams);

        _vehicleColorService.GetVehicleColorCollection(customRequest, default)
            .Returns([]);

        // Act
        await _handler.Handle(customRequest, default);

        // Assert
        await _vehicleColorService
            .Received()
            .GetVehicleColorCollection(
                Arg.Is<CollectionVehicleColorsQueryRequest>(r =>
                    r.FilteringParameters.PageIndex == 2 &&
                    r.FilteringParameters.PageSize == 10),
                default!);
    }

    [Fact]
    public async Task Handler_ShouldReturnSuccessResult_WithCorrectPageIndex()
    {
        // Arrange
        var customFilteringParams = new VehicleColorFilteringRequestParameters
        {
            PageIndex = 3
        };
        var customRequest = new CollectionVehicleColorsQueryRequest(customFilteringParams);

        List<VehicleColorDto> colors =
        [
            new VehicleColorDto("#FFFFFF") { Id = Guid.NewGuid(), Name = "Білий" }
        ];

        _vehicleColorService.GetVehicleColorCollection(customRequest, default)
            .Returns(colors);

        // Act
        var result = await _handler.Handle(customRequest, default);

        // Assert
        result.IsSuccess
            .Should().BeTrue();

        result.Value!.PageIndex
            .Should()
            .Be(3);
    }

    [Fact]
    public async Task Handler_ShouldHandleLargeCollections_Correctly()
    {
        // Arrange
        var largeColorCollection = Enumerable.Range(1, 100)
            .Select(i => new VehicleColorDto($"#{i % 10:D2}{i % 10:D1}0000")
            {
                Id = Guid.NewGuid(),
                Name = $"Колір {i}"
            })
            .ToList();

        _vehicleColorService.GetVehicleColorCollection(_request, default)
            .Returns(largeColorCollection);

        // Act
        var result = await _handler.Handle(_request, default);

        // Assert
        result.IsSuccess
            .Should().BeTrue();

        result.Value!.Items
            .Should()
            .HaveCount(100);

        result.Value.Items
            .Should()
            .BeEquivalentTo(largeColorCollection);
    }

    [Fact]
    public async Task Handler_ShouldPreserveColorProperties_InResult()
    {
        // Arrange
        var specificColor = new VehicleColorDto("#FF5733")
        {
            Id = Guid.Parse("12345678-1234-1234-1234-123456789abc"),
            Name = "Помаранчевий"
        };

        List<VehicleColorDto> colors = [specificColor];

        _vehicleColorService.GetVehicleColorCollection(_request, default)
            .Returns(colors);

        // Act
        var result = await _handler.Handle(_request, default);

        // Assert
        result.IsSuccess
            .Should().BeTrue();

        var returnedColor = result.Value!.Items.First();
        returnedColor.Id
            .Should()
            .Be(Guid.Parse("12345678-1234-1234-1234-123456789abc"));

        returnedColor.Name
            .Should()
            .Be("Помаранчевий");

        returnedColor.HexValue
            .Should()
            .Be("#FF5733");
    }
}