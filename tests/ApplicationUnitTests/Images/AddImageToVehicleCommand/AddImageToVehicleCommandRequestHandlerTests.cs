using LanosCertifiedStore.Application.Images;
using LanosCertifiedStore.Application.Images.Commands.AddImageToVehicleCommandRequestRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.Vehicles;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using Microsoft.AspNetCore.Http;

namespace ApplicationUnitTests.Images.AddImageToVehicleCommand;

public sealed class AddImageToVehicleCommandRequestHandlerTests
{
    private readonly IVehicleService _vehicleService = Substitute.For<IVehicleService>();
    private readonly IImageService _imageService = Substitute.For<IImageService>();
    private readonly AddImagesToVehicleCommandRequestHandler _requestHandler;

    public AddImageToVehicleCommandRequestHandlerTests()
    {
        _requestHandler = new AddImagesToVehicleCommandRequestHandler(_vehicleService, _imageService);
    }

    [Fact]
    public async Task Handler_ShouldReturnError_WhenVehicleDoesNotExist()
    {
        // Arrange
        var request = AddImagesToVehicleCommandRequestTestExemplars.WithInvalidVehicleId();
        _vehicleService.ExistsById(request.VehicleId, Arg.Any<CancellationToken>()).Returns(false);

        // Act
        var result = await _requestHandler.Handle(request, default);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().Be(Error.NotFound(request.VehicleId));
    }

    [Fact]
    public async Task Handler_ShouldReturnError_WhenImageUploadFails()
    {
        // Arrange
        var request = AddImagesToVehicleCommandRequestTestExemplars.WithInvalidVehicleId();
        _vehicleService.ExistsById(request.VehicleId, Arg.Any<CancellationToken>()).Returns(true);
        _imageService.UploadImageAsync(Arg.Any<IFormFile>(), Arg.Any<string>())
            .Returns(new ImageResult(false, default, default));

        // Act
        var result = await _requestHandler.Handle(request, default);

        // Assert
        result.IsSuccess.Should().BeFalse();
    }

    [Fact]
    public async Task Handler_ShouldNotInvokeAddImagesToVehicle_WhenNoImagesAreUploaded()
    {
        // Arrange
        var request = AddImagesToVehicleCommandRequestTestExemplars.WithEmptyImages();
        _vehicleService.ExistsById(request.VehicleId, Arg.Any<CancellationToken>()).Returns(true);

        // Act
        await _requestHandler.Handle(request, default);

        // Assert
        await _vehicleService.DidNotReceive().AddImagesToVehicle(Arg.Any<Guid>(), Arg.Any<List<VehicleImage>>(),
            Arg.Any<CancellationToken>());
    }
    
    [Fact]
    public async Task Handler_ShouldSucceed_WhenRequestIsRegular()
    {
        // Arrange
        var request = AddImagesToVehicleCommandRequestTestExemplars.Regular();
        _vehicleService.ExistsById(request.VehicleId, Arg.Any<CancellationToken>()).Returns(true);
        _imageService.UploadImageAsync(Arg.Any<IFormFile>(), Arg.Any<string>()).Returns(new ImageResult(true, Guid.NewGuid().ToString(), default));

        // Act
        var result = await _requestHandler.Handle(request, default);

        // Assert
        result.IsSuccess.Should().BeTrue();
        await _vehicleService.Received(1).AddImagesToVehicle(request.VehicleId, Arg.Is<List<VehicleImage>>(x => x.Count == 1), Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task Handler_ShouldSucceed_WhenRequestHasMultipleImages()
    {
        // Arrange
        var request = AddImagesToVehicleCommandRequestTestExemplars.WithMultipleImages();
        _vehicleService.ExistsById(request.VehicleId, Arg.Any<CancellationToken>()).Returns(true);
        _imageService.UploadImageAsync(Arg.Any<IFormFile>(), Arg.Any<string>()).Returns(new ImageResult(true, Guid.NewGuid().ToString(), default));

        // Act
        var result = await _requestHandler.Handle(request, default);

        // Assert
        result.IsSuccess.Should().BeTrue();
        await _vehicleService.Received(1).AddImagesToVehicle(request.VehicleId, Arg.Is<List<VehicleImage>>(x => x.Count == 3), Arg.Any<CancellationToken>());
    }
}