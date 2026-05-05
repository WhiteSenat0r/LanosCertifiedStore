using IntegrationTests.Common;
using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.VehicleTypes;
using LanosCertifiedStore.Application.VehicleTypes.Queries.CollectionVehicleTypesQueryRelated;

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
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();

        types
            .Should().BeInAscendingOrder(b => b.Name);
        types.Count
            .Should().BeLessOrEqualTo((int)ItemQuantitySelection.Ten);
    }

    [Fact]
    public async Task Send_CollectionRequest_WithDescendingSort_Should_ReturnTypesInDescendingOrder()
    {
        // Arrange
        var filteringRequestParameters = new VehicleTypeFilteringRequestParameters
        {
            ItemQuantity = ItemQuantitySelection.Ten,
            SortingType = "name-desc",
            PageIndex = 1
        };
        var queryRequest = new CollectionVehicleTypesQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var types = response.Value!.Items;

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();

        types
            .Should().BeInDescendingOrder(b => b.Name);
        types.Count
            .Should().BeLessOrEqualTo((int)ItemQuantitySelection.Ten);
    }

    [Fact]
    public async Task Send_CollectionRequest_WithPagination_Should_ReturnCorrectPage()
    {
        // Arrange
        var filteringRequestParameters = new VehicleTypeFilteringRequestParameters
        {
            ItemQuantity = ItemQuantitySelection.Five,
            SortingType = "name-asc",
            PageIndex = 2
        };
        var queryRequest = new CollectionVehicleTypesQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var result = response.Value!;
        var types = result.Items;

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();

        result.PageIndex
            .Should().Be(2);
        result.CurrentPageItemsQuantity
            .Should().Be(types.Count);

        types
            .Should().BeInAscendingOrder(b => b.Name);
        types.Count
            .Should().BeLessOrEqualTo((int)ItemQuantitySelection.Five);
    }

    [Fact]
    public async Task Send_CollectionRequest_WithHighPageIndex_Should_HandleGracefully()
    {
        // Arrange
        var filteringRequestParameters = new VehicleTypeFilteringRequestParameters
        {
            ItemQuantity = ItemQuantitySelection.Ten,
            SortingType = "name-asc",
            PageIndex = 999
        };
        var queryRequest = new CollectionVehicleTypesQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var types = response.Value!.Items;

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();

        types.Count
            .Should().BeGreaterOrEqualTo(0);
    }

    [Theory]
    [InlineData(ItemQuantitySelection.Twenty)]
    [InlineData(ItemQuantitySelection.Fifty)]
    public async Task Send_CollectionRequest_WithDifferentItemQuantities_Should_RespectLimit(
        ItemQuantitySelection itemQuantity)
    {
        // Arrange
        var filteringRequestParameters = new VehicleTypeFilteringRequestParameters
        {
            ItemQuantity = itemQuantity,
            SortingType = "name-asc",
            PageIndex = 1
        };
        var queryRequest = new CollectionVehicleTypesQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var types = response.Value!.Items;

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();

        types.Count
            .Should().BeLessOrEqualTo((int)itemQuantity);
    }
}