using System.Linq.Expressions;
using FluentValidation.TestHelper;
using LanosCertifiedStore.Application.Shared.ValidationRelated;
using LanosCertifiedStore.Application.VehicleBrands;
using LanosCertifiedStore.Application.VehicleBrands.Commands.UpdateVehicleBrandRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;

namespace ApplicationUnitTests.VehicleBrands.UpdateVehicleBrandCommand;

public sealed class UpdateVehicleBrandCommandRequestValidatorTests
{
    private const int MaxNameLength = 64;

    private readonly IValidationHelper _validationHelper = Substitute.For<IValidationHelper>();
    private readonly UpdateVehicleBrandCommandRequestValidator _validator;

    public UpdateVehicleBrandCommandRequestValidatorTests()
    {
        _validator = new UpdateVehicleBrandCommandRequestValidator(_validationHelper);
    }

    [Fact]
    public async Task Should_HaveError_WhenUpdatedNameIsEmpty()
    {
        await AssertValidationError(string.Empty);
    }

    [Fact]
    public async Task Should_HaveError_WhenUpdatedNameIsTooShort()
    {
        await AssertValidationError("A");
    }

    [Fact]
    public async Task Should_HaveError_WhenUpdatedNameIsTooLong()
    {
        await AssertValidationError(new string('A', MaxNameLength + 1));
    }

    [Fact]
    public async Task Should_HaveError_WhenUpdatedNameIsNotUnique()
    {
        _validationHelper
            .CheckAspectValueUniqueness(Arg.Any<string>(), Arg.Any<Expression<Func<VehicleBrand, bool>>>())
            .Returns(false);

        var result = await ValidateRequest("ExistingBrand");

        result.ShouldHaveValidationErrorFor(x => x.UpdatedName)
            .WithErrorMessage(VehicleBrandValidatorMessages.AlreadyExistingNameValue);
    }

    private async Task AssertValidationError(string updatedName)
    {
        var result = await ValidateRequest(updatedName);
        result.ShouldHaveValidationErrorFor(x => x.UpdatedName);
    }

    private async Task<TestValidationResult<UpdateVehicleBrandCommandRequest>> ValidateRequest(string updatedName)
    {
        var request = new UpdateVehicleBrandCommandRequest(Guid.NewGuid(), updatedName);
        return await _validator.TestValidateAsync(request);
    }
}
