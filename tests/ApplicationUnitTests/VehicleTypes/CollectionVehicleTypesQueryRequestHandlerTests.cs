﻿using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.VehicleTypes;
using LanosCertifiedStore.Application.VehicleTypes.Queries.CollectionVehicleTypesQueryRelated;

namespace ApplicationUnitTests.VehicleTypes;

public sealed class CollectionVehicleTypesQueryRequestHandlerTests
{
    private readonly IVehicleTypeService _vehicleTypeService = Substitute.For<IVehicleTypeService>();
    private readonly CollectionVehicleTypesQueryRequestHandler _handler;
    private readonly CollectionVehicleTypesQueryRequest _request = new(new VehicleTypeFilteringRequestParameters());

    public CollectionVehicleTypesQueryRequestHandlerTests()
    {
        _handler = new CollectionVehicleTypesQueryRequestHandler(_vehicleTypeService);
    }

    [Fact]
    public async Task Handler_ShouldInvokeGetVehicleTypeCollection_FromVehicleTypeService()
    {
        // Act
        await _handler.Handle(_request, default);

        // Assert
        await _vehicleTypeService
            .Received()
            .GetVehicleTypeCollection(_request, default!);
    }

    [Fact]
    public async Task Handler_ShouldReturnCollectionOfVehicleTypes()
    {
        // Arrange
        List<VehicleTypeDto> expectedTypes =
        [
            new VehicleTypeDto { Id = Guid.NewGuid(), Name = "Легковик" },
            new VehicleTypeDto { Id = Guid.NewGuid(), Name = "Вантажівка" },
            new VehicleTypeDto { Id = Guid.NewGuid(), Name = "Автобус" }
        ];

        var expectedResult = new PaginationResult<VehicleTypeDto>(
            expectedTypes,
            _request.FilteringParameters.PageIndex);

        _vehicleTypeService.GetVehicleTypeCollection(_request, default)
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