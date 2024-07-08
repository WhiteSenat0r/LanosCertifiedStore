using Application.Contracts.ServicesRelated;
using Application.Dtos.TypeDtos;
using Application.QueryRequests.TypesRelated.VehicleBodyTypeRelated.CollectionVehicleBodyTypesQueryRelated;
using Application.RequestParameters.TypeRelated;
using Application.Shared.ResultRelated;
using FluentAssertions;
using NSubstitute;

namespace ApplicationUnitTests.VehicleBodyTypes;

public sealed class CollectionVehicleBodyTypesQueryRequestHandlerTests
{
    private readonly IVehicleBodyTypeService _vehicleBodyTypeService = Substitute.For<IVehicleBodyTypeService>();
    private readonly CollectionVehicleBodyTypesQueryRequestHandler _handler;
    private readonly CollectionVehicleBodyTypesQueryRequest _request = new(new VehicleBodyTypeFilteringRequestParameters());

    public CollectionVehicleBodyTypesQueryRequestHandlerTests()
    {
        _handler = new CollectionVehicleBodyTypesQueryRequestHandler(_vehicleBodyTypeService);
    }

    [Fact]
    public async Task Handler_ShouldInvokeGetVehicleBodyTypeCollection_FromVehicleBodyTypeService()
    {
        // Act
        await _handler.Handle(_request, default);

        // Assert
        await _vehicleBodyTypeService
            .Received()
            .GetVehicleBodyTypeCollection(_request, default!);
    }

    [Fact]
    public async Task Handler_ShouldReturnCollectionOfVehicleBodyTypes()
    {
        // Arrange
        List<VehicleBodyTypeDto> expectedDrivetrainTypes =
        [
            new VehicleBodyTypeDto { Id = Guid.NewGuid(), Name = "Седан" },
            new VehicleBodyTypeDto { Id = Guid.NewGuid(), Name = "Хетчбек" },
            new VehicleBodyTypeDto { Id = Guid.NewGuid(), Name = "Універсал" }
        ];

        var expectedResult = new PaginationResult<VehicleBodyTypeDto>(
            expectedDrivetrainTypes,
            _request.FilteringParameters.PageIndex);

        _vehicleBodyTypeService.GetVehicleBodyTypeCollection(_request, default)
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