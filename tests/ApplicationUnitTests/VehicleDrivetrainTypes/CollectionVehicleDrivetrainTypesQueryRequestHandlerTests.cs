using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.VehicleDrivetrainTypes;
using LanosCertifiedStore.Application.VehicleDrivetrainTypes.Queries.CollectionVehicleDrivetrainTypesQueryRequestRelated;

namespace ApplicationUnitTests.VehicleDrivetrainTypes;

public sealed class CollectionVehicleDrivetrainTypesQueryRequestHandlerTests
{
    private readonly IVehicleDrivetrainTypeService _vehicleDrivetrainTypeService = Substitute.For<IVehicleDrivetrainTypeService>();
    private readonly CollectionVehicleDrivetrainTypesQueryRequestHandler _handler;
    private readonly CollectionVehicleDrivetrainTypesQueryRequest _request = new(new VehicleDrivetrainTypeFilteringRequestParameters());

    public CollectionVehicleDrivetrainTypesQueryRequestHandlerTests()
    {
        _handler = new CollectionVehicleDrivetrainTypesQueryRequestHandler(_vehicleDrivetrainTypeService);
    }

    [Fact]
    public async Task Handler_ShouldInvokeGetVehicleDrivetrainTypeCollection_FromVehicleDrivetrainTypeService()
    {
        // Act
        await _handler.Handle(_request, default);

        // Assert
        await _vehicleDrivetrainTypeService
            .Received()
            .GetVehicleDrivetrainTypeCollection(_request, default!);
    }

    [Fact]
    public async Task Handler_ShouldReturnCollectionOfVehicleDrivetrainTypes()
    {
        // Arrange
        List<VehicleDrivetrainTypeDto> expectedDrivetrainTypes =
        [
            new VehicleDrivetrainTypeDto { Id = Guid.NewGuid(), Name = "Передній" },
            new VehicleDrivetrainTypeDto { Id = Guid.NewGuid(), Name = "Задній" },
            new VehicleDrivetrainTypeDto { Id = Guid.NewGuid(), Name = "Повний" }
        ];

        var expectedResult = new PaginationResult<VehicleDrivetrainTypeDto>(
            expectedDrivetrainTypes,
            _request.FilteringParameters.PageIndex);

        _vehicleDrivetrainTypeService.GetVehicleDrivetrainTypeCollection(_request, default)
            .Returns(expectedDrivetrainTypes);

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