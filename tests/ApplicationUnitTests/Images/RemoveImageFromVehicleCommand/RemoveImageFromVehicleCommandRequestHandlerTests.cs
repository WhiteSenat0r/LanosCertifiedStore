using LanosCertifiedStore.Application.Images;
using LanosCertifiedStore.Application.Images.Commands.RemoveImageFromVehicleCommandRequestRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.Vehicles;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using LanosCertifiedStore.Application.Vehicles.Queries.SingleVehicleQueryRequestRelated;

namespace ApplicationUnitTests.Images.RemoveImageFromVehicleCommand;

public sealed class RemoveImageFromVehicleCommandRequestHandlerTests
{
    private readonly IVehicleService _vehicleService = Substitute.For<IVehicleService>();
    private readonly IImageService _imageService = Substitute.For<IImageService>();
    private readonly RemoveImageFromVehicleCommandRequestHandler _requestHandler;

    public RemoveImageFromVehicleCommandRequestHandlerTests()
    {
        _requestHandler = new RemoveImageFromVehicleCommandRequestHandler(_imageService, _vehicleService);
    }

    [Fact]
    public async Task Handler_ShouldReturnError_WhenVehicleDoesNotExist()
    {
        // Arrange
        var request = new RemoveImageFromVehicleCommandRequest(Guid.NewGuid(), "image-cloud-id");
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
        var request = new RemoveImageFromVehicleCommandRequest(Guid.NewGuid(), "image-cloud-id");

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
        var request = new RemoveImageFromVehicleCommandRequest(Guid.NewGuid(), "image-cloud-id");

        _vehicleService.GetVehicle(Arg.Any<SingleVehicleQueryRequest>(), Arg.Any<CancellationToken>())
            .Returns(vehicle);

        // Act
        var result = await _requestHandler.Handle(request, default);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().Be(ImageErrors.NotFound(request.ImageCloudId));
    }

    [Fact]
    public async Task Handler_ShouldReturnError_WhenTryingToDeleteMainImage()
    {
        // Arrange
        var request = new RemoveImageFromVehicleCommandRequest(Guid.NewGuid(), "image-cloud-id");
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
        result.Error.Should().Be(ImageErrors.DeletingMainImage);
    }

    [Fact]
    public async Task Handler_ShouldReturnError_WhenImageRemovalFails()
    {
        // Arrange
        var request = new RemoveImageFromVehicleCommandRequest(Guid.NewGuid(), "image-cloud-id");
        var vehicle = new SingleVehicleDto
        {
            Images = new List<ImageDto>
            {
                new ImageDto { CloudImageId = request.ImageCloudId, IsMainImage = false }
            }
        };

        _vehicleService.GetVehicle(Arg.Any<SingleVehicleQueryRequest>(), Arg.Any<CancellationToken>())
            .Returns(vehicle);

        _imageService.TryDeletePhotoAsync(request.ImageCloudId).Returns(false);

        // Act
        var result = await _requestHandler.Handle(request, default);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().Be(ImageErrors.UnsuccessfulRemoval);
    }

    [Fact]
    public async Task Handler_ShouldSucceed_WhenRemovingNonMainImage()
    {
        // Arrange
        var request = new RemoveImageFromVehicleCommandRequest(Guid.NewGuid(), "image-cloud-id");
        var vehicle = new SingleVehicleDto
        {
            Images = new List<ImageDto>
            {
                new ImageDto { CloudImageId = request.ImageCloudId, IsMainImage = false }
            }
        };

        _vehicleService.GetVehicle(Arg.Any<SingleVehicleQueryRequest>(), Arg.Any<CancellationToken>())
            .Returns(vehicle);

        _imageService.TryDeletePhotoAsync(request.ImageCloudId).Returns(true);

        // Act
        var result = await _requestHandler.Handle(request, default);

        // Assert
        result.IsSuccess.Should().BeTrue();
        await _vehicleService.Received(1)
            .RemoveImageFromVehicle(request.VehicleId, request.ImageCloudId, Arg.Any<CancellationToken>());
    }
}