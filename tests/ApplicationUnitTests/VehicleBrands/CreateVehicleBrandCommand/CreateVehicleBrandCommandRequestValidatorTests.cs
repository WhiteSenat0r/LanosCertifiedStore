﻿using System.Linq.Expressions;
using FluentValidation.TestHelper;
using LanosCertifiedStore.Application.Shared.ValidationRelated;
using LanosCertifiedStore.Application.VehicleBrands;
using LanosCertifiedStore.Application.VehicleBrands.Commands.CreateVehicleBrandRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;

namespace ApplicationUnitTests.VehicleBrands.CreateVehicleBrandCommand;

public sealed class CreateVehicleBrandCommandRequestValidatorTests
{
    private readonly IValidationHelper _validationHelper = Substitute.For<IValidationHelper>();
    private readonly CreateVehicleBrandCommandRequestValidator _validator;

    public CreateVehicleBrandCommandRequestValidatorTests()
    {
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
        var model = new CreateVehicleBrandCommandRequest(new string('A', 65));

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
            .Returns(false);

        // Act
        var result = await _validator.TestValidateAsync(model);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Name)
            .WithErrorMessage(VehicleBrandValidatorMessages.AlreadyExistingNameValue);
    }
}