using Application.LocationRegions;
using Application.LocationRegions.Queries.CollectionLocationRegionsQueryRequestRelated;
using Application.Shared.RequestParamsRelated;
using IntegrationTests.Common;

namespace IntegrationTests.LocationRegions;

public sealed class LocationRegionQueriesIntegrationTests(
    IntegrationTestsWebApplicationFactory factory) : IntegrationTestBase(factory)
{
    [Fact]
    public async Task Send_CollectionRequest_Should_ReturnCollectionOfLocationRegions()
    {
        // Arrange
        var filteringRequestParameters = new VehicleLocationRegionFilteringRequestParameters
        {
            ItemQuantity = ItemQuantitySelection.Ten,
            SortingType = "name-asc",
            PageIndex = 1
        };
        var queryRequest = new CollectionLocationRegionsQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var regions = response.Value!.Items;

        // Assert
        response.Error
            .Should().BeNull();
        response.IsSuccess
            .Should().BeTrue();

        regions
            .Should().BeInAscendingOrder(b => b.Name);
        regions.Count
            .Should().BeLessOrEqualTo((int)ItemQuantitySelection.Ten);
    }
}