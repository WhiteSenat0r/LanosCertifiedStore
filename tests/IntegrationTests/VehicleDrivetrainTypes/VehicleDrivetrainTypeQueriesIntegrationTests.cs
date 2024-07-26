using IntegrationTests.Common;
using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Application.VehicleDrivetrainTypes;
using LanosCertifiedStore.Application.VehicleDrivetrainTypes.Queries.CollectionVehicleDrivetrainTypesQueryRequestRelated;

namespace IntegrationTests.VehicleDrivetrainTypes;

public sealed class VehicleDrivetrainTypeQueriesIntegrationTests(
    IntegrationTestsWebApplicationFactory factory) : IntegrationTestBase(factory)
{
    [Fact]
    public async Task Send_CollectionRequest_Should_ReturnCollectionOfDrivetrainTypes()
    {
        // Arrange
        var filteringRequestParameters = new VehicleDrivetrainTypeFilteringRequestParameters
        {
            ItemQuantity = ItemQuantitySelection.Ten,
            SortingType = "name-asc",
            PageIndex = 1
        };
        var queryRequest = new CollectionVehicleDrivetrainTypesQueryRequest(filteringRequestParameters);

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