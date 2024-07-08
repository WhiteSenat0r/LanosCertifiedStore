using Application.VehicleBrands;
using Application.VehicleBrands.Commands.CreateVehicleBrandRelated;

namespace ApplicationUnitTests.VehicleBrands.CreateVehicleBrandCommand;

public sealed class CreateVehicleBrandCommandHandlerTests
{
    private readonly IVehicleBrandService _vehicleBrandService = Substitute.For<IVehicleBrandService>();
    private readonly CreateVehicleBrandCommandHandler _handler;
    private readonly CreateVehicleBrandCommandRequest _request = new("test brand");

    public CreateVehicleBrandCommandHandlerTests()
    {
        _handler = new CreateVehicleBrandCommandHandler(_vehicleBrandService);
    }

    [Fact]
    public async Task Handler_ShouldInvokeAddNewVehicleBrand_FromVehicleBrandService()
    {
        // Act
        await _handler.Handle(_request, default);

        // Assert
        await _vehicleBrandService
            .Received()
            .AddNewVehicleBrand(_request, default!);
    }

    [Fact]
    public async Task Handler_ShouldReturnCreatedBrandId()
    {
        // Arrange
        var expectedId = Guid.NewGuid();

        _vehicleBrandService.AddNewVehicleBrand(_request, default)
            .Returns(expectedId);

        // Act
        var result = await _handler.Handle(_request, default);

        // Assert
        result.IsSuccess
            .Should().BeTrue();

        result.Value
            .Should()
            .Be(expectedId);
    }
}