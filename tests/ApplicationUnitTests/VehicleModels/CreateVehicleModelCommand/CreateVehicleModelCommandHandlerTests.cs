using Application.VehicleModels;
using Application.VehicleModels.Commands.CreateVehicleModelRelated;

namespace ApplicationUnitTests.VehicleModels.CreateVehicleModelCommand;

public sealed class CreateVehicleModelCommandHandlerTests
{
    private readonly IVehicleModelService _vehicleModelService = Substitute.For<IVehicleModelService>();
    private readonly CreateVehicleModelCommandRequestHandler _requestHandler;
    private readonly CreateVehicleModelCommandRequest _request = CreateVehicleModelCommandTestExemplars.Regular();

    public CreateVehicleModelCommandHandlerTests()
    {
        _requestHandler = new CreateVehicleModelCommandRequestHandler(_vehicleModelService);
    }

    [Fact]
    public async Task Handler_ShouldInvokeAddNewVehicleModel_FromVehicleModelService()
    {
        // Act
        await _requestHandler.Handle(_request, default);

        // Assert
        await _vehicleModelService
            .Received()
            .AddNewVehicleModel(_request, default!);
    }

    [Fact]
    public async Task Handler_ShouldReturnCreatedBrandId()
    {
        // Arrange
        var expectedId = Guid.NewGuid();

        _vehicleModelService.AddNewVehicleModel(_request, default)
            .Returns(expectedId);

        // Act
        var result = await _requestHandler.Handle(_request, default);

        // Assert
        result.IsSuccess
            .Should().BeTrue();

        result.Value
            .Should()
            .Be(expectedId);
    }


}