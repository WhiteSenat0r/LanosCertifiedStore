using Application.Shared.RequestParamsRelated;
using Application.VehicleTransmissionTypes;
using Application.VehicleTransmissionTypes.Queries.CollectionVehicleTransmissionTypesQueryRelated;
using IntegrationTests.Common;

namespace IntegrationTests.VehicleTransmissionTypes;

public sealed class VehicleTransmissionTypeQueriesIntegrationTests(
    IntegrationTestsWebApplicationFactory factory) : IntegrationTestBase(factory)
{
    [Fact]
    public async Task Send_CollectionRequest_Should_ReturnCollectionOfTransmissionTypes()
    {
        // Arrange
        var filteringRequestParameters = new VehicleTransmissionTypeFilteringRequestParameters
        {
            ItemQuantity = ItemQuantitySelection.Ten,
            SortingType = "name-asc",
            PageIndex = 1
        };
        var queryRequest = new CollectionVehicleTransmissionTypesQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var transmissionTypes = response.Value!.Items;

        // Assert
        response.Error
            .Should().BeNull();
        response.IsSuccess
            .Should().BeTrue();

        transmissionTypes
            .Should().BeInAscendingOrder(b => b.Name);
        transmissionTypes.Count
            .Should().BeLessOrEqualTo((int)ItemQuantitySelection.Ten);
    }
}