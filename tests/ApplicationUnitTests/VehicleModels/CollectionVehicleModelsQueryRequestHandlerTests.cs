using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.VehicleModels;
using LanosCertifiedStore.Application.VehicleModels.Dtos;
using LanosCertifiedStore.Application.VehicleModels.Queries.CollectionVehicleModelsQueryRelated;

namespace ApplicationUnitTests.VehicleModels;

public sealed class CollectionVehicleModelsQueryRequestHandlerTests
{
    private readonly IVehicleModelService _vehicleModelService = Substitute.For<IVehicleModelService>();
    private readonly CollectionVehicleModelsQueryRequestHandler _handler;
    private readonly CollectionVehicleModelsQueryRequest _request = new(new VehicleModelFilteringRequestParameters());

    public CollectionVehicleModelsQueryRequestHandlerTests()
    {
        _handler = new CollectionVehicleModelsQueryRequestHandler(_vehicleModelService);
    }

    [Fact]
    public async Task Handler_ShouldInvokeGetVehicleModelCollection_FromVehicleModelService()
    {
        // Act
        await _handler.Handle(_request, default);

        // Assert
        await _vehicleModelService
            .Received()
            .GetVehicleModelCollection(_request, default!);
    }

    [Fact]
    public async Task Handler_ShouldReturnCollectionOfVehicleModels()
    {
        // Arrange
        List<VehicleModelDto> expectedModels =
        [
            new VehicleModelDto { Id = Guid.NewGuid(), Name = "Легковик" },
            new VehicleModelDto { Id = Guid.NewGuid(), Name = "Вантажівка" },
            new VehicleModelDto { Id = Guid.NewGuid(), Name = "Автобус" }
        ];

        var expectedResult = new PaginationResult<VehicleModelDto>(
            expectedModels,
            _request.FilteringParameters.PageIndex);

        _vehicleModelService.GetVehicleModelCollection(_request, default)
            .Returns(expectedModels);

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