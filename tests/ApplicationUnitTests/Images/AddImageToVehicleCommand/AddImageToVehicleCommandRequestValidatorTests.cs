using FluentValidation.TestHelper;
using LanosCertifiedStore.Application.Images.Commands.AddImageToVehicleCommandRequestRelated;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace ApplicationUnitTests.Images.AddImageToVehicleCommand;

public sealed class AddImagesToVehicleCommandRequestValidatorTests
{
    private readonly AddImagesToVehicleCommandRequestValidator _validator;

    public AddImagesToVehicleCommandRequestValidatorTests()
    {
        _validator = new AddImagesToVehicleCommandRequestValidator();
    }

    [Fact]
    public async Task Should_HaveError_WhenImagesCollectionIsEmpty()
    {
        var model = new AddImagesToVehicleCommandRequest(Guid.NewGuid(), new List<IFormFile>());

        var result = await _validator.TestValidateAsync(model);

        result.ShouldHaveValidationErrorFor(x => x.Images);
    }

    [Fact]
    public async Task Should_HaveError_WhenAnyImageHasInvalidFormat()
    {
        var invalidImage = new FormFile(Stream.Null, 0, 1000, "file", "file.txt")
        {
            Headers = new HeaderDictionary(),
            ContentType = "text/plain"
        };

        var model = new AddImagesToVehicleCommandRequest(Guid.NewGuid(), new List<IFormFile> { invalidImage });

        var result = await _validator.TestValidateAsync(model);

        result.ShouldHaveValidationErrorFor(x => x.Images);
    }

    [Fact]
    public async Task Should_HaveError_WhenAnyImageHasZeroSize()
    {
        var zeroSizeImage = new FormFile(Stream.Null, 0, 0, "file", "image.jpg")
        {
            Headers = new HeaderDictionary(),
            ContentType = "image/jpeg"
        };

        var model = new AddImagesToVehicleCommandRequest(Guid.NewGuid(), new List<IFormFile> { zeroSizeImage });

        var result = await _validator.TestValidateAsync(model);

        result.ShouldHaveValidationErrorFor(x => x.Images);
    }

    [Fact]
    public async Task Should_HaveError_WhenVehicleIdIsEmpty()
    {
        var validImage = new FormFile(Stream.Null, 0, 1000, "file", "image.jpg")
        {
            Headers = new HeaderDictionary(),
            ContentType = "image/jpeg"
        };

        var model = new AddImagesToVehicleCommandRequest(Guid.Empty, new List<IFormFile> { validImage });

        var result = await _validator.TestValidateAsync(model);

        result.ShouldHaveValidationErrorFor(x => x.VehicleId);
    }

    [Fact]
    public async Task Should_NotHaveError_WhenModelIsValid()
    {
        var validImage = new FormFile(Stream.Null, 0, 1000, "file", "image.jpg")
        {
            Headers = new HeaderDictionary(),
            ContentType = "image/jpeg"
        };

        var model = new AddImagesToVehicleCommandRequest(Guid.NewGuid(), new List<IFormFile> { validImage });

        var result = await _validator.TestValidateAsync(model);

        result.ShouldNotHaveValidationErrorFor(x => x.Images);
        result.ShouldNotHaveValidationErrorFor(x => x.VehicleId);
    }
}
