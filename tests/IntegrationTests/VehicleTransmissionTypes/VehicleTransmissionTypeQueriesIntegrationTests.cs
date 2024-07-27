using IntegrationTests.Common;
using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.VehicleTransmissionTypes;
using LanosCertifiedStore.Application.VehicleTransmissionTypes.Queries.CollectionVehicleTransmissionTypesQueryRelated;

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
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();

        transmissionTypes
            .Should().BeInAscendingOrder(b => b.Name);
        transmissionTypes.Count
            .Should().BeLessOrEqualTo((int)ItemQuantitySelection.Ten);
    }
}