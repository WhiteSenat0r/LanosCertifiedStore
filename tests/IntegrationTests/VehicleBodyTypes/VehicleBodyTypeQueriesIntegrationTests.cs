using Application.Shared.RequestParamsRelated;
using Application.VehicleBodyTypes;
using Application.VehicleBodyTypes.Queries.CollectionVehicleBodyTypesQueryRelated;
using IntegrationTests.Common;

namespace IntegrationTests.VehicleBodyTypes;

public sealed class VehicleBodyTypeQueriesIntegrationTests(
    IntegrationTestsWebApplicationFactory factory) : IntegrationTestBase(factory)
{
    [Fact]
    public async Task Send_CollectionRequest_Should_ReturnCollectionOfBodyTypes()
    {
        // Arrange
        var filteringRequestParameters = new VehicleBodyTypeFilteringRequestParameters
        {
            ItemQuantity = ItemQuantitySelection.Ten,
            SortingType = "name-asc",
            PageIndex = 1
        };
        var queryRequest = new CollectionVehicleBodyTypesQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var bodyTypes = response.Value!.Items;

        // Assert
        response.Error
            .Should().BeNull();
        response.IsSuccess
            .Should().BeTrue();

        bodyTypes
            .Should().BeInAscendingOrder(b => b.Name);
        bodyTypes.Count
            .Should().BeLessOrEqualTo((int)ItemQuantitySelection.Ten);
    }
}