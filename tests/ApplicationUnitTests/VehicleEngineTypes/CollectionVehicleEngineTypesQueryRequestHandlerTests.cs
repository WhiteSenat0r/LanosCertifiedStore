using Application.Shared.ResultRelated;
using Application.VehicleEngineTypes;
using Application.VehicleEngineTypes.Queries.CollectionVehicleEngineTypesQueryRelated;

namespace ApplicationUnitTests.VehicleEngineTypes;

public sealed class CollectionVehicleEngineTypesQueryRequestHandlerTests
{
    private readonly IVehicleEngineTypeService _vehicleEngineTypeService = Substitute.For<IVehicleEngineTypeService>();
    private readonly CollectionVehicleEngineTypesQueryRequestHandler _handler;
    private readonly CollectionVehicleEngineTypesQueryRequest _request = new(new VehicleEngineTypeFilteringRequestParameters());

    public CollectionVehicleEngineTypesQueryRequestHandlerTests()
    {
        _handler = new CollectionVehicleEngineTypesQueryRequestHandler(_vehicleEngineTypeService);
    }

    [Fact]
    public async Task Handler_ShouldInvokeGetVehicleEngineTypeCollection_FromVehicleEngineTypeService()
    {
        // Act
        await _handler.Handle(_request, default);

        // Assert
        await _vehicleEngineTypeService
            .Received()
            .GetVehicleEngineTypeCollection(_request, default!);
    }

    [Fact]
    public async Task Handler_ShouldReturnCollectionOfVehicleEngineTypes()
    {
        // Arrange
        List<VehicleEngineTypeDto> expectedEngineTypes =
        [
            new VehicleEngineTypeDto { Id = Guid.NewGuid(), Name = "Бензиновий" },
            new VehicleEngineTypeDto { Id = Guid.NewGuid(), Name = "Газовий" },
            new VehicleEngineTypeDto { Id = Guid.NewGuid(), Name = "Електро" }
        ];

        var expectedResult = new PaginationResult<VehicleEngineTypeDto>(
            expectedEngineTypes,
            _request.FilteringParameters.PageIndex);

        _vehicleEngineTypeService.GetVehicleEngineTypeCollection(_request, default)
            .Returns(expectedEngineTypes);

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