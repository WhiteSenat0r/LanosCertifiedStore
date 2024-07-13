using Application.Shared.RequestParamsRelated;
using Application.VehicleTypes;
using Application.VehicleTypes.Queries.CollectionVehicleTypesQueryRelated;
using IntegrationTests.Common;

namespace IntegrationTests.VehicleTypes;

public sealed class VehicleTypeQueriesIntegrationTests(
    IntegrationTestsWebApplicationFactory factory) : IntegrationTestBase(factory)
{
    [Fact]
    public async Task Send_CollectionRequest_Should_ReturnCollectionOfTypes()
    {
        // Arrange
        var filteringRequestParameters = new VehicleTypeFilteringRequestParameters
        {
            ItemQuantity = ItemQuantitySelection.Ten,
            SortingType = "name-asc",
            PageIndex = 1
        };
        var queryRequest = new CollectionVehicleTypesQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var types = response.Value!.Items;

        // Assert
        response.Error
            .Should().BeNull();
        response.IsSuccess
            .Should().BeTrue();

        types
            .Should().BeInAscendingOrder(b => b.Name);
        types.Count
            .Should().BeLessOrEqualTo((int)ItemQuantitySelection.Ten);
    }
}