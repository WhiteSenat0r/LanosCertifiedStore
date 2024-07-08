using System.Linq.Expressions;
using Application.Shared.ValidationRelated;
using Application.VehicleBrands;
using Application.VehicleBrands.Commands.CreateVehicleBrandRelated;
using Domain.Constants.VehicleRelated;
using Domain.Entities.VehicleRelated;
using FluentValidation.TestHelper;

namespace ApplicationUnitTests.VehicleBrands.CreateVehicleBrandCommand;

public class CreateVehicleBrandCommandRequestValidatorTests
{
    private readonly IValidationHelper _validationHelper;
    private readonly CreateVehicleBrandCommandRequestValidator _validator;

    public CreateVehicleBrandCommandRequestValidatorTests()
    {
        _validationHelper = Substitute.For<IValidationHelper>();
        _validator = new CreateVehicleBrandCommandRequestValidator(_validationHelper);
    }

    [Fact]
    public async Task Should_HaveError_WhenNameIsEmpty()
    {
        // Arrange
        var model = new CreateVehicleBrandCommandRequest(string.Empty);

        // Act
        var result = await _validator.TestValidateAsync(model);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public async Task Should_HaveError_WhenNameIsTooShort()
    {
        // Arrange
        var model = new CreateVehicleBrandCommandRequest("A");

        // Act
        var result = await _validator.TestValidateAsync(model);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public async Task Should_HaveError_WhenNameIsTooLong()
    {
        // Arrange
        var model = new CreateVehicleBrandCommandRequest(new string('A', VehicleBrandConstants.MaximumNameLength + 1));

        // Act
        var result = await _validator.TestValidateAsync(model);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public async Task Should_HaveError_WhenNameIsNotUnique()
    {
        // Arrange
        var model = new CreateVehicleBrandCommandRequest("ExistingBrand");

        _validationHelper
            .CheckAspectValueUniqueness(Arg.Any<string>(), Arg.Any<Expression<Func<VehicleBrand, bool>>>())
            .Returns(Task.FromResult(false));

        // Act
        var result = await _validator.TestValidateAsync(model);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Name)
            .WithErrorMessage(VehicleBrandValidatorMessages.AlreadyExistingNameValue);
    }

    [Fact]
    public async Task Should_NotHaveError_WhenNameIsUnique()
    {
        // Arrange
        var model = new CreateVehicleBrandCommandRequest("UniqueBrand");

        _validationHelper
            .CheckAspectValueUniqueness(Arg.Any<string>(), Arg.Any<Expression<Func<VehicleBrand, bool>>>())
            .Returns(Task.FromResult(true));

        // Act
        var result = await _validator.TestValidateAsync(model);

        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public async Task Should_NotHaveError_WhenNameIsValid()
    {
        // Arrange
        var model = new CreateVehicleBrandCommandRequest("test name");

        _validationHelper
            .CheckAspectValueUniqueness(Arg.Any<string>(), Arg.Any<Expression<Func<VehicleBrand, bool>>>())
            .Returns(Task.FromResult(true));

        // Act
        var result = await _validator.TestValidateAsync(model);

        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.Name);
    }
}