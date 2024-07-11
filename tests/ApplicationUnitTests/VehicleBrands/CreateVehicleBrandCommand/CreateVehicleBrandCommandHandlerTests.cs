using Application.VehicleBrands;
using Application.VehicleBrands.Commands.CreateVehicleBrandRelated;

namespace ApplicationUnitTests.VehicleBrands.CreateVehicleBrandCommand;

public sealed class CreateVehicleBrandCommandRequestHandlerTests
{
    private readonly IVehicleBrandService _vehicleBrandService = Substitute.For<IVehicleBrandService>();
    private readonly CreateVehicleBrandCommandRequestHandler _requestHandler;
    private readonly CreateVehicleBrandCommandRequest _request = new("test brand");

    public CreateVehicleBrandCommandRequestHandlerTests()
    {
        _requestHandler = new CreateVehicleBrandCommandRequestHandler(_vehicleBrandService);
    }

    [Fact]
    public async Task Handler_ShouldInvokeAddNewVehicleBrand_FromVehicleBrandService()
    {
        // Act
        await _requestHandler.Handle(_request, default);

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
        var result = await _requestHandler.Handle(_request, default);

        // Assert
        result.IsSuccess
            .Should().BeTrue();

        result.Value
            .Should()
            .Be(expectedId);
    }
}