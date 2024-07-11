using Application.Shared.ValidationRelated;
using Application.VehicleModels.Commands.UpdateVehicleModelRelated;
using Domain.Entities.VehicleRelated.TypeRelated;
using FluentValidation.TestHelper;

namespace ApplicationUnitTests.VehicleModels.UpdateVehicleModelCommand;

public sealed class UpdateVehicleModelCommandRequestValidatorTests
{
    private readonly IValidationHelper _validationHelper = Substitute.For<IValidationHelper>();
    private readonly UpdateVehicleModelCommandRequestValidator _validator;

    public UpdateVehicleModelCommandRequestValidatorTests()
    {
        _validator = new UpdateVehicleModelCommandRequestValidator(_validationHelper);
    }

    [Fact]
    public async Task Should_HaveError_WhenAnyOfTransmissionTypesDoesNotExist()
    {
        // Arrange
        var model = UpdateVehicleModelCommandTestExemplars.Regular();

        _validationHelper
            .CheckMainAspectPresence<VehicleTransmissionType>(Arg.Any<IEnumerable<Guid>>())
            .Returns((Guid.NewGuid(), false));

        // Act
        var result = await _validator.TestValidateAsync(model);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.AvailableTransmissionTypesIds);
    }

    [Fact]
    public async Task Should_HaveError_WhenAnyOfBodyTypesDoesNotExist()
    {
        // Arrange
        var model = UpdateVehicleModelCommandTestExemplars.Regular();

        _validationHelper
            .CheckMainAspectPresence<VehicleBodyType>(Arg.Any<IEnumerable<Guid>>())
            .Returns((Guid.NewGuid(), false));

        // Act
        var result = await _validator.TestValidateAsync(model);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.AvailableBodyTypesIds);
    }

    [Fact]
    public async Task Should_HaveError_WhenAnyOfDrivetrainTypesDoesNotExist()
    {
        // Arrange
        var model = UpdateVehicleModelCommandTestExemplars.Regular();

        _validationHelper
            .CheckMainAspectPresence<VehicleDrivetrainType>(Arg.Any<IEnumerable<Guid>>())
            .Returns((Guid.NewGuid(), false));

        // Act
        var result = await _validator.TestValidateAsync(model);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.AvailableDrivetrainTypesIds);
    }

    [Fact]
    public async Task Should_HaveError_WhenAnyOfEngineTypesDoesNotExist()
    {
        // Arrange
        var model = UpdateVehicleModelCommandTestExemplars.Regular();

        _validationHelper
            .CheckMainAspectPresence<VehicleEngineType>(Arg.Any<IEnumerable<Guid>>())
            .Returns((Guid.NewGuid(), false));

        // Act
        var result = await _validator.TestValidateAsync(model);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.AvailableEngineTypesIds);
    }
}