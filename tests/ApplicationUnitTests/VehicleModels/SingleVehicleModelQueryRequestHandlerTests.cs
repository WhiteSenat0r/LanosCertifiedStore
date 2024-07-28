using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.VehicleModels;
using LanosCertifiedStore.Application.VehicleModels.Dtos;
using LanosCertifiedStore.Application.VehicleModels.Queries.SingleVehicleModelQueryRelated;
using NSubstitute.ReturnsExtensions;

namespace ApplicationUnitTests.VehicleModels;

public sealed class SingleVehicleModelQueryRequestHandlerTests
{
    private readonly IVehicleModelService _vehicleModelService = Substitute.For<IVehicleModelService>();
    private readonly SingleVehicleModelQueryRequestHandler _handler;
    private readonly SingleVehicleModelQueryRequest _request;
    private readonly Guid _modelId = Guid.NewGuid();

    public SingleVehicleModelQueryRequestHandlerTests()
    {
        _handler = new SingleVehicleModelQueryRequestHandler(_vehicleModelService);
        _request = new SingleVehicleModelQueryRequest(_modelId);
    }

    [Fact]
    public async Task Handler_ShouldInvokeGetSingleVehicleModel_FromVehicleModelService()
    {
        // Act
        await _handler.Handle(_request, default);

        // Assert
        await _vehicleModelService
            .Received()
            .GetSingleVehicleModel(_request, default!);
    }

    [Fact]
    public async Task Handler_ShouldReturnVehicleModel_IfExists()
    {
        // Arrange
        var expectedModel = new SingleVehicleModelDto { Id = Guid.NewGuid(), Name = "Легковик" };

        _vehicleModelService.GetSingleVehicleModel(_request, default)
            .Returns(expectedModel);

        // Act
        var result = await _handler.Handle(_request, default);

        // Assert
        result.IsSuccess
            .Should().BeTrue();

        result.Value
            .Should()
            .Be(expectedModel);
    }

    [Fact]
    public async Task Handler_ShouldReturnFailureResult_IfModelDoesNotExists()
    {
        // Arrange
        _vehicleModelService.GetSingleVehicleModel(_request, default)
            .ReturnsNull();

        // Act
        var result = await _handler.Handle(_request, default);

        // Assert
        result.IsSuccess.Should().BeFalse();

        result.Error
            .Should()
            .BeEquivalentTo(Error.NotFound(_modelId));
    }
}