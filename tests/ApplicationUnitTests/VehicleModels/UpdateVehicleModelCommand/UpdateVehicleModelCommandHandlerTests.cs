using Application.Shared.ResultRelated;
using Application.VehicleModels;
using Application.VehicleModels.Commands.UpdateVehicleModelRelated;
using NSubstitute.ExceptionExtensions;

namespace ApplicationUnitTests.VehicleModels.UpdateVehicleModelCommand;

public sealed class UpdateVehicleModelCommandHandlerTests
{
    private readonly IVehicleModelService _vehicleModelService = Substitute.For<IVehicleModelService>();
    private readonly UpdateVehicleModelCommandRequestHandler _handler;

    private readonly UpdateVehicleModelCommandRequest _request = new(
        Guid.NewGuid(),
        2005,
        [Guid.NewGuid(), Guid.NewGuid()],
        [Guid.NewGuid(), Guid.NewGuid()],
        [Guid.NewGuid(), Guid.NewGuid()],
        [Guid.NewGuid(), Guid.NewGuid()]);

    public UpdateVehicleModelCommandHandlerTests()
    {
        _handler = new UpdateVehicleModelCommandRequestHandler(_vehicleModelService);
    }

    [Fact]
    public async Task Handler_ShouldInvokeAddNewVehicleModel_FromVehicleModelService()
    {
        // Act
        await _handler.Handle(_request, default);

        // Assert
        await _vehicleModelService
            .Received()
            .UpdateVehicleModel(_request, default!);
    }

    [Fact]
    public async Task Handler_ShouldReturnSuccessResult_IfBrandFound()
    {
        // Act
        var result = await _handler.Handle(_request, default);

        // Arrange
        result.IsSuccess
            .Should().BeTrue();
    }

    [Fact]
    public async Task Handler_ShouldReturnFailureResult_IfBrandWasNotFound()
    {
        // Arrange
        var exception = new KeyNotFoundException();
        _vehicleModelService.UpdateVehicleModel(_request, default)
            .Throws(exception);

        // Act
        var result = await _handler.Handle(_request, default);

        // Assert
        result.IsSuccess
            .Should().BeFalse();

        result.Error
            .Should()
            .BeEquivalentTo(Error.NotFound(exception.Message));
    }
}