using System.Globalization;
using IntegrationTests.Common;
using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.VehicleColors;
using LanosCertifiedStore.Application.VehicleColors.Queries.CollectionVehicleColorsQueryRequestRelated;

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
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();

        colors
            .Should().BeInAscendingOrder(b => b.Name,
                StringComparer.Create(new CultureInfo("uk-UA"), ignoreCase: true));
        colors.Count
            .Should().BeLessOrEqualTo((int)ItemQuantitySelection.Ten);
    }

    [Fact]
    public async Task Send_CollectionRequest_WithDescendingSort_Should_ReturnColorsInDescendingOrder()
    {
        // Arrange
        var filteringRequestParameters = new VehicleColorFilteringRequestParameters
        {
            ItemQuantity = ItemQuantitySelection.Ten,
            SortingType = "name-desc",
            PageIndex = 1
        };
        var queryRequest = new CollectionVehicleColorsQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var colors = response.Value!.Items;

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();

        colors
            .Should().BeInDescendingOrder(b => b.Name,
                StringComparer.Create(new CultureInfo("uk-UA"), ignoreCase: true));
        colors.Count
            .Should().BeLessOrEqualTo((int)ItemQuantitySelection.Ten);
    }

    [Fact]
    public async Task Send_CollectionRequest_WithPagination_Should_ReturnCorrectPage()
    {
        // Arrange
        var filteringRequestParameters = new VehicleColorFilteringRequestParameters
        {
            ItemQuantity = ItemQuantitySelection.Five,
            SortingType = "name-asc",
            PageIndex = 2
        };
        var queryRequest = new CollectionVehicleColorsQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var result = response.Value!;
        var colors = result.Items;

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();

        result.PageIndex
            .Should().Be(2);
        result.CurrentPageItemsQuantity
            .Should().Be(colors.Count);

        colors
            .Should().BeInAscendingOrder(b => b.Name,
                StringComparer.Create(new CultureInfo("uk-UA"), ignoreCase: true));
        colors.Count
            .Should().BeLessOrEqualTo((int)ItemQuantitySelection.Five);
    }

    [Fact]
    public async Task Send_CollectionRequest_WithHighPageIndex_Should_HandleGracefully()
    {
        // Arrange
        var filteringRequestParameters = new VehicleColorFilteringRequestParameters
        {
            ItemQuantity = ItemQuantitySelection.Ten,
            SortingType = "name-asc",
            PageIndex = 100
        };
        var queryRequest = new CollectionVehicleColorsQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var colors = response.Value!.Items;

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();

        colors.Count
            .Should().BeGreaterOrEqualTo(0);
    }

    [Fact]
    public async Task Send_CollectionRequest_WithDifferentItemQuantities_Should_RespectLimit()
    {
        // Arrange
        var filteringRequestParameters = new VehicleColorFilteringRequestParameters
        {
            ItemQuantity = ItemQuantitySelection.Twenty,
            SortingType = "name-asc",
            PageIndex = 1
        };
        var queryRequest = new CollectionVehicleColorsQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var colors = response.Value!.Items;

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();

        colors.Count
            .Should().BeLessOrEqualTo((int)ItemQuantitySelection.Twenty);
    }
}