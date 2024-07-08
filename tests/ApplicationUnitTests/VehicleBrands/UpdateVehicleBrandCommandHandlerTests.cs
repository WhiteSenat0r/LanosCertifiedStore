using Application.CommandRequests.VehicleBrandsRelated.UpdateVehicleBrandRelated;
using Application.Contracts.ServicesRelated;
using Application.Shared.ResultRelated;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace ApplicationUnitTests.VehicleBrands;

public sealed class UpdateVehicleBrandCommandHandlerTests
{
    private readonly IVehicleBrandService _vehicleBrandService = Substitute.For<IVehicleBrandService>();
    private readonly UpdateVehicleBrandCommandRequestHandler _handler;
    private readonly UpdateVehicleBrandCommandRequest _request = new(Guid.NewGuid(), "test brand");

    public UpdateVehicleBrandCommandHandlerTests()
    {
        _handler = new UpdateVehicleBrandCommandRequestHandler(_vehicleBrandService);
    }

    [Fact]
    public async Task Handler_ShouldInvokeAddNewVehicleBrand_FromVehicleBrandService()
    {
        // Act
        await _handler.Handle(_request, default);

        // Assert
        await _vehicleBrandService
            .Received()
            .UpdateVehicleBrand(_request, default!);
    }

    [Fact]
    public async Task Handler_ShouldReturnSuccessResult_IfBrandFound()
    {
        // Act
        var result = await _handler.Handle(_request, default);
        
        // Arrange
        result.IsSuccess
            .Should().BeTrue();
    }

    [Fact]
    public async Task Handler_ShouldReturnFailureResult_IfBrandWasNotFound()
    {
        // Arrange
        _vehicleBrandService.UpdateVehicleBrand(_request, default)
            .Throws(new KeyNotFoundException());
        
        // Act
        var result = await _handler.Handle(_request, default);
        
        // Assert
        result.IsSuccess
            .Should().BeFalse();

        result.Error
            .Should()
            .BeEquivalentTo(Error.NotFound(_request.Id));
    }
}