using System.Globalization;
using IntegrationTests.Common;
using LanosCertifiedStore.Application.LocationRegions;
using LanosCertifiedStore.Application.LocationRegions.Queries.CollectionLocationRegionsQueryRequestRelated;
using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;

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
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();

        regions
            .Should().BeInAscendingOrder(b => b.Name,
                StringComparer.Create(new CultureInfo("uk-UA"), ignoreCase: true));
        regions.Count
            .Should().BeLessOrEqualTo((int)ItemQuantitySelection.Ten);
    }
}