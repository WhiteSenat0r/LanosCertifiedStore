using Application.Contracts.ServicesRelated;
using Application.Dtos.TypeDtos;
using Application.QueryRequests.TypesRelated.VehicleTransmissionTypeRelated.CollectionVehicleTransmissionTypesQueryRelated;
using Application.RequestParameters.TypeRelated;
using Application.Shared.ResultRelated;
using FluentAssertions;
using NSubstitute;

namespace ApplicationUnitTests.VehicleTransmissionTypes;

public sealed class CollectionVehicleTransmissionTypesQueryRequestHandlerTests
{
    private readonly IVehicleTransmissionTypeService _vehicleTransmissionTypeService = Substitute.For<IVehicleTransmissionTypeService>();
    private readonly CollectionVehicleTransmissionTypesQueryRequestHandler _handler;
    private readonly CollectionVehicleTransmissionTypesQueryRequest _request = new(new VehicleTransmissionTypeFilteringRequestParameters());

    public CollectionVehicleTransmissionTypesQueryRequestHandlerTests()
    {
        _handler = new CollectionVehicleTransmissionTypesQueryRequestHandler(_vehicleTransmissionTypeService);
    }

    [Fact]
    public async Task Handler_ShouldInvokeGetVehicleTransmissionTypeCollection_FromVehicleTransmissionTypeService()
    {
        // Act
        await _handler.Handle(_request, default);

        // Assert
        await _vehicleTransmissionTypeService
            .Received()
            .GetVehicleTransmissionTypeCollection(_request, default!);
    }

    [Fact]
    public async Task Handler_ShouldReturnCollectionOfVehicleTransmissionTypes()
    {
        // Arrange
        List<VehicleTransmissionTypeDto> expectedTypes =
        [
            new VehicleTransmissionTypeDto { Id = Guid.NewGuid(), Name = "Легковик" },
            new VehicleTransmissionTypeDto { Id = Guid.NewGuid(), Name = "Вантажівка" },
            new VehicleTransmissionTypeDto { Id = Guid.NewGuid(), Name = "Автобус" }
        ];

        var expectedResult = new PaginationResult<VehicleTransmissionTypeDto>(
            expectedTypes,
            _request.FilteringParameters.PageIndex);

        _vehicleTransmissionTypeService.GetVehicleTransmissionTypeCollection(_request, default)
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