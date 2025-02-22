using LanosCertifiedStore.Application.Images;
using LanosCertifiedStore.Application.Images.Commands.SetVehicleMainImageCommandRequestRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.Vehicles;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using LanosCertifiedStore.Application.Vehicles.Queries.SingleVehicleQueryRequestRelated;

namespace ApplicationUnitTests.Images.SetVehicleMainImageCommand;

public sealed class SetVehicleMainImageCommandRequestHandlerTests
{
    private readonly IVehicleService _vehicleService = Substitute.For<IVehicleService>();
    private readonly SetVehicleMainImageCommandRequestHandler _requestHandler;

    public SetVehicleMainImageCommandRequestHandlerTests()
    {
        _requestHandler = new SetVehicleMainImageCommandRequestHandler(_vehicleService);
    }

    [Fact]
    public async Task Handler_ShouldReturnError_WhenVehicleDoesNotExist()
    {
        // Arrange
        var request = new SetVehicleMainImageCommandRequest(Guid.NewGuid(), "image-cloud-id");
        _vehicleService.GetVehicle(Arg.Any<SingleVehicleQueryRequest>(), Arg.Any<CancellationToken>())
            .Returns((SingleVehicleDto)null);

        // Act
        var result = await _requestHandler.Handle(request, default);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().Be(Error.NotFound(request.VehicleId));
    }

    [Fact]
    public async Task Handler_ShouldReturnError_WhenVehicleHasNoImages()
    {
        // Arrange
        var vehicle = new SingleVehicleDto { Images = new List<ImageDto>() };
        var request = new SetVehicleMainImageCommandRequest(Guid.NewGuid(), "image-cloud-id");

        _vehicleService.GetVehicle(Arg.Any<SingleVehicleQueryRequest>(), Arg.Any<CancellationToken>())
            .Returns(vehicle);

        // Act
        var result = await _requestHandler.Handle(request, default);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().Be(ImageErrors.NoImages);
    }

    [Fact]
    public async Task Handler_ShouldReturnError_WhenImageIsNotFound()
    {
        // Arrange
        var vehicle = new SingleVehicleDto
        {
            Images = new List<ImageDto>
            {
                new ImageDto { CloudImageId = "different-image-id", IsMainImage = false }
            }
        };
        var request = new SetVehicleMainImageCommandRequest(Guid.NewGuid(), "image-cloud-id");

        _vehicleService.GetVehicle(Arg.Any<SingleVehicleQueryRequest>(), Arg.Any<CancellationToken>())
            .Returns(vehicle);

        // Act
        var result = await _requestHandler.Handle(request, default);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().Be(ImageErrors.NotFound(request.ImageCloudId));
    }

    [Fact]
    public async Task Handler_ShouldReturnError_WhenImageIsAlreadyMain()
    {
        // Arrange
        var request = new SetVehicleMainImageCommandRequest(Guid.NewGuid(), "image-cloud-id");
        var vehicle = new SingleVehicleDto
        {
            Images = new List<ImageDto>
            {
                new ImageDto { CloudImageId = request.ImageCloudId, IsMainImage = true }
            }
        };

        _vehicleService.GetVehicle(Arg.Any<SingleVehicleQueryRequest>(), Arg.Any<CancellationToken>())
            .Returns(vehicle);

        // Act
        var result = await _requestHandler.Handle(request, default);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().Be(ImageErrors.AlreadyMainImage);
    }

    [Fact]
    public async Task Handler_ShouldSucceed_WhenSettingMainImage()
    {
        // Arrange
        var request = new SetVehicleMainImageCommandRequest(Guid.NewGuid(), "image-cloud-id");
        var vehicle = new SingleVehicleDto
        {
            Images = new List<ImageDto>
            {
                new ImageDto { CloudImageId = "image-cloud-id", IsMainImage = false }
            }
        };

        _vehicleService.GetVehicle(Arg.Any<SingleVehicleQueryRequest>(), Arg.Any<CancellationToken>())
            .Returns(vehicle);

        // Act
        var result = await _requestHandler.Handle(request, default);

        // Assert
        result.IsSuccess.Should().BeTrue();
        await _vehicleService.Received(1)
            .SetMainImage(request.VehicleId, request.ImageCloudId, Arg.Any<CancellationToken>());
    }
}