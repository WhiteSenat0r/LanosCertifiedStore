using System.Globalization;
using Application.Shared.RequestParamsRelated;
using Application.VehicleColors;
using Application.VehicleColors.Queries.CollectionVehicleColorsQueryRequestRelated;
using IntegrationTests.Common;

namespace IntegrationTests.VehicleColors;

public sealed class VehicleColorQueriesIntegrationTests(
    IntegrationTestsWebApplicationFactory factory) : IntegrationTestBase(factory)
{
    [Fact]
    public async Task Send_CollectionRequest_Should_ReturnCollectionOfColors()
    {
        // Arrange
        var filteringRequestParameters = new VehicleColorFilteringRequestParameters
        {
            ItemQuantity = ItemQuantitySelection.Ten,
            SortingType = "name-asc",
            PageIndex = 1
        };
        var queryRequest = new CollectionVehicleColorsQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var colors = response.Value!.Items;

        // Assert
        response.Error.Should().BeNull();
        response.IsSuccess.Should().BeTrue();

        colors.Should().BeInAscendingOrder(
            b => b.Name, 
            StringComparer.Create(new CultureInfo("uk-UA"), ignoreCase: true));
        colors.Count.Should().Be((int)ItemQuantitySelection.Ten);
    }
}