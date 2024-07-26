using IntegrationTests.Common;
using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Application.VehicleEngineTypes;
using LanosCertifiedStore.Application.VehicleEngineTypes.Queries.CollectionVehicleEngineTypesQueryRelated;

namespace IntegrationTests.VehicleEngineTypes;

public sealed class VehicleEngineTypeQueriesIntegrationTests(
    IntegrationTestsWebApplicationFactory factory) : IntegrationTestBase(factory)
{
    [Fact]
    public async Task Send_CollectionRequest_Should_ReturnCollectionOfEngineTypes()
    {
        // Arrange
        var filteringRequestParameters = new VehicleEngineTypeFilteringRequestParameters
        {
            ItemQuantity = ItemQuantitySelection.Ten,
            SortingType = "name-asc",
            PageIndex = 1
        };
        var queryRequest = new CollectionVehicleEngineTypesQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var engineTypes = response.Value!.Items;

        // Assert
        response.Error
            .Should().BeNull();
        response.IsSuccess
            .Should().BeTrue();

        engineTypes
            .Should().BeInAscendingOrder(b => b.Name);
        engineTypes.Count
            .Should().BeLessOrEqualTo((int)ItemQuantitySelection.Ten);
    }
}