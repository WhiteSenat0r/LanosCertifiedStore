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
}