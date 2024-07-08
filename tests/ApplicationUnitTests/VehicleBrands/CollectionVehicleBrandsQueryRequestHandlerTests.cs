using Application.Contracts.ServicesRelated;
using Application.Dtos.BrandDtos;
using Application.QueryRequests.VehicleBrandsRelated.CollectionVehicleBrandsQueryRelated;
using Application.RequestParameters;
using Application.Shared.ResultRelated;
using FluentAssertions;
using NSubstitute;

namespace ApplicationUnitTests.VehicleBrands;

public sealed class CollectionVehicleBrandsQueryRequestHandlerTests
{
    private readonly IVehicleBrandService _vehicleBrandService = Substitute.For<IVehicleBrandService>();
    private readonly CollectionVehicleBrandsQueryRequestHandler _handler;
    private readonly CollectionVehicleBrandsQueryRequest _request = new(new VehicleBrandFilteringRequestParameters());

    public CollectionVehicleBrandsQueryRequestHandlerTests()
    {
        _handler = new CollectionVehicleBrandsQueryRequestHandler(_vehicleBrandService);
    }

    [Fact]
    public async Task Handler_ShouldInvokeGetVehicleBrandCollection_FromVehicleBrandService()
    {
        // Act
        await _handler.Handle(_request, default);

        // Assert
        await _vehicleBrandService
            .Received()
            .GetVehicleBrandCollection(_request, default!);
    }

    [Fact]
    public async Task Handler_ShouldReturnCollectionOfVehicleBrands()
    {
        // Arrange
        List<VehicleBrandDto> expectedTypes =
        [
            new VehicleBrandDto { Id = Guid.NewGuid(), Name = "Легковик" },
            new VehicleBrandDto { Id = Guid.NewGuid(), Name = "Вантажівка" },
            new VehicleBrandDto { Id = Guid.NewGuid(), Name = "Автобус" }
        ];

        var expectedResult = new PaginationResult<VehicleBrandDto>(
            expectedTypes,
            _request.FilteringParameters.PageIndex);

        _vehicleBrandService.GetVehicleBrandCollection(_request, default)
            .Returns(expectedTypes);

        // Act
        var result = await _handler.Handle(_request, default);

        // Assert
        result.IsSuccess
            .Should().BeTrue();

        result.Value
            .Should()
            .BeEquivalentTo(expectedResult);
    }
}