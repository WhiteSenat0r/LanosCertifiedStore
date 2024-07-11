using Application.Shared.DtosRelated;
using Application.VehicleModels;
using Application.VehicleModels.Queries.CountVehicleModelsQueryRelated;

namespace ApplicationUnitTests.VehicleModels;

public sealed class CountVehicleModelsQueryRequestHandlerTests
{
    private readonly IVehicleModelService _vehicleModelService = Substitute.For<IVehicleModelService>();
    private readonly CountVehicleModelsQueryRequestHandler _handler;
    private readonly CountVehicleModelsQueryRequest _request = new(new VehicleModelFilteringRequestParameters());

    public CountVehicleModelsQueryRequestHandlerTests()
    {
        _handler = new CountVehicleModelsQueryRequestHandler(_vehicleModelService);
    }

    [Fact]
    public async Task Handler_ShouldInvokeGetVehicleModelsCount_FromVehicleModelService()
    {
        // Act
        await _handler.Handle(_request, default);

        // Assert
        await _vehicleModelService
            .Received()
            .GetVehicleModelsCount(_request, default!);
    }

    [Fact]
    public async Task Handler_ShouldReturnCountOfVehicleModels()
    {
        // Arrange
        var vehicleModelCount = new ItemsCountDto(3, 3);

        _vehicleModelService.GetVehicleModelsCount(_request, default)
            .Returns(vehicleModelCount);

        // Act
        var result = await _handler.Handle(_request, default);

        // Assert
        result.IsSuccess
            .Should().BeTrue();

        result.Value
            .Should()
            .Be(vehicleModelCount);
    }
}