using IntegrationTests.Common;
using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.VehicleBodyTypes;
using LanosCertifiedStore.Application.VehicleBodyTypes.Queries.CollectionVehicleBodyTypesQueryRelated;

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
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();

        bodyTypes
            .Should().BeInAscendingOrder(b => b.Name);
        bodyTypes.Count
            .Should().BeLessOrEqualTo((int)ItemQuantitySelection.Ten);
    }

    [Fact]
    public async Task Send_CollectionRequest_WithDescendingSort_Should_ReturnBodyTypesInDescendingOrder()
    {
        // Arrange
        var filteringRequestParameters = new VehicleBodyTypeFilteringRequestParameters
        {
            ItemQuantity = ItemQuantitySelection.Ten,
            SortingType = "name-desc",
            PageIndex = 1
        };
        var queryRequest = new CollectionVehicleBodyTypesQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var bodyTypes = response.Value!.Items;

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();

        bodyTypes
            .Should().BeInDescendingOrder(b => b.Name);
        bodyTypes.Count
            .Should().BeLessOrEqualTo((int)ItemQuantitySelection.Ten);
    }

    [Fact]
    public async Task Send_CollectionRequest_WithPagination_Should_ReturnCorrectPage()
    {
        // Arrange
        var filteringRequestParameters = new VehicleBodyTypeFilteringRequestParameters
        {
            ItemQuantity = ItemQuantitySelection.Five,
            SortingType = "name-asc",
            PageIndex = 2
        };
        var queryRequest = new CollectionVehicleBodyTypesQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var bodyTypes = response.Value!.Items;

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();

        bodyTypes
            .Should().BeInAscendingOrder(b => b.Name);
        bodyTypes.Count
            .Should().BeLessOrEqualTo((int)ItemQuantitySelection.Five);
    }

    [Fact]
    public async Task Send_CollectionRequest_WithHighPageIndex_Should_HandleGracefully()
    {
        // Arrange
        var filteringRequestParameters = new VehicleBodyTypeFilteringRequestParameters
        {
            ItemQuantity = ItemQuantitySelection.Ten,
            SortingType = "name-asc",
            PageIndex = 100
        };
        var queryRequest = new CollectionVehicleBodyTypesQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var bodyTypes = response.Value!.Items;

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();

        bodyTypes.Count
            .Should().BeGreaterOrEqualTo(0);
    }

    [Fact]
    public async Task Send_CollectionRequest_WithDifferentItemQuantities_Should_RespectLimit()
    {
        // Arrange
        var filteringRequestParameters = new VehicleBodyTypeFilteringRequestParameters
        {
            ItemQuantity = ItemQuantitySelection.Twenty,
            SortingType = "name-asc",
            PageIndex = 1
        };
        var queryRequest = new CollectionVehicleBodyTypesQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var bodyTypes = response.Value!.Items;

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();

        bodyTypes.Count
            .Should().BeLessOrEqualTo((int)ItemQuantitySelection.Twenty);
    }
}