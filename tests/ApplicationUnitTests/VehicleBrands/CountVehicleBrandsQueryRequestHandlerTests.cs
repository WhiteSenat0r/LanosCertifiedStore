using Application.Shared.DtosRelated;
using Application.VehicleBrands;
using Application.VehicleBrands.Queries.CountVehicleBrandsQueryRelated;
using FluentAssertions;
using NSubstitute;

namespace ApplicationUnitTests.VehicleBrands;

public sealed class CountVehicleBrandsQueryRequestHandlerTests
{
    private readonly IVehicleBrandService _vehicleBrandService = Substitute.For<IVehicleBrandService>();
    private readonly CountVehicleBrandsQueryRequestHandler _handler;
    private readonly CountVehicleBrandsQueryRequest _request = new(new VehicleBrandFilteringRequestParameters());

    public CountVehicleBrandsQueryRequestHandlerTests()
    {
        _handler = new CountVehicleBrandsQueryRequestHandler(_vehicleBrandService);
    }

    [Fact]
    public async Task Handler_ShouldInvokeGetVehicleBrandsCount_FromVehicleBrandService()
    {
        // Act
        await _handler.Handle(_request, default);

        // Assert
        await _vehicleBrandService
            .Received()
            .GetVehicleBrandsCount(_request, default!);
    }

    [Fact]
    public async Task Handler_ShouldReturnCountOfVehicleBrands()
    {
        // Arrange
        var vehicleBrandCount = new ItemsCountDto(3, 3);

        _vehicleBrandService.GetVehicleBrandsCount(_request, default)
            .Returns(vehicleBrandCount);

        // Act
        var result = await _handler.Handle(_request, default);

        // Assert
        result.IsSuccess
            .Should().BeTrue();

        result.Value
            .Should()
            .Be(vehicleBrandCount);
    }
}