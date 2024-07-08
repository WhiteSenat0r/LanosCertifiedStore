using Application.Contracts.ServicesRelated;
using Application.Dtos.BrandDtos;
using Application.QueryRequests.VehicleBrandsRelated.SingleVehicleBrandQueryRelated;
using Application.Shared.ResultRelated;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace ApplicationUnitTests.VehicleBrands;

public sealed class SingleVehicleBrandQueryRequestHandlerTests
{
    private readonly IVehicleBrandService _vehicleBrandService = Substitute.For<IVehicleBrandService>();
    private readonly SingleVehicleBrandQueryRequestHandler _handler;
    private readonly SingleVehicleBrandQueryRequest _request;
    private readonly Guid _brandId = Guid.NewGuid();

    public SingleVehicleBrandQueryRequestHandlerTests()
    {
        _handler = new SingleVehicleBrandQueryRequestHandler(_vehicleBrandService);
        _request = new SingleVehicleBrandQueryRequest(_brandId);
    }

    [Fact]
    public async Task Handler_ShouldInvokeGetSingleVehicleBrand_FromVehicleBrandService()
    {
        // Act
        await _handler.Handle(_request, default);

        // Assert
        await _vehicleBrandService
            .Received()
            .GetSingleVehicleBrand(_request, default!);
    }

    [Fact]
    public async Task Handler_ShouldReturnVehicleBrand_IfExists()
    {
        // Arrange
        var expectedBrand = new SingleVehicleBrandDto([]) { Id = Guid.NewGuid(), Name = "Легковик" };

        _vehicleBrandService.GetSingleVehicleBrand(_request, default)
            .Returns(expectedBrand);

        // Act
        var result = await _handler.Handle(_request, default);

        // Assert
        result.IsSuccess
            .Should().BeTrue();

        result.Value
            .Should()
            .Be(expectedBrand);
    }

    [Fact]
    public async Task Handler_ShouldReturnFailureResult_IfBrandDoesNotExists()
    {
        // Arrange
        _vehicleBrandService.GetSingleVehicleBrand(_request, default)
            .ReturnsNull();

        // Act
        var result = await _handler.Handle(_request, default);

        // Assert
        result.IsSuccess.Should().BeFalse();

        result.Error
            .Should()
            .BeEquivalentTo(Error.NotFound(_brandId));
    }
}