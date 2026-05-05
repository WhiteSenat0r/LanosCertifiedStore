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
    private static readonly StringComparer UkrainianCaseInsensitiveComparer =
        StringComparer.Create(new CultureInfo("uk-UA"), ignoreCase: true);

    private static CollectionVehicleColorsQueryRequest CreateQueryRequest(
        ItemQuantitySelection itemQuantity,
        string sortingType,
        int pageIndex) =>
        new(new VehicleColorFilteringRequestParameters
        {
            ItemQuantity = itemQuantity,
            SortingType = sortingType,
            PageIndex = pageIndex
        });

    private static void AssertSuccessfulResponse<T>(Result<T> response)
    {
        response.Error.Should().Be(Error.None);
        response.IsSuccess.Should().BeTrue();
    }

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
        response.Error.Should()
.Be(Error.None);
        response.IsSuccess.Should().BeTrue();

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
        var queryRequest = CreateQueryRequest(ItemQuantitySelection.Ten, "name-desc", pageIndex: 1);

        // Act
        var response = await Sender.Send(queryRequest);
        var colors = response.Value!.Items;

        // Assert
        AssertSuccessfulResponse(response);

        colors
            .Should().BeInDescendingOrder(c => c.Name, UkrainianCaseInsensitiveComparer);
        colors.Count
            .Should().BeLessOrEqualTo((int)ItemQuantitySelection.Ten);
    }

    [Fact]
    public async Task Send_CollectionRequest_WithPageTwo_Should_ReturnDifferentColorsFromPageOne()
    {
        // Arrange
        var queryRequestPage1 = CreateQueryRequest(ItemQuantitySelection.Ten, "name-asc", pageIndex: 1);
        var queryRequestPage2 = CreateQueryRequest(ItemQuantitySelection.Ten, "name-asc", pageIndex: 2);

        // Act
        var responsePage1 = await Sender.Send(queryRequestPage1);
        var responsePage2 = await Sender.Send(queryRequestPage2);
        var colorsPage1 = responsePage1.Value!.Items;
        var colorsPage2 = responsePage2.Value!.Items;

        // Assert
        AssertSuccessfulResponse(responsePage1);
        AssertSuccessfulResponse(responsePage2);

        // If we have data on page 2, it should be different from page 1
        if (colorsPage2.Count > 0)
        {
            var page1Ids = colorsPage1.Select(c => c.Id).ToList();
            var page2Ids = colorsPage2.Select(c => c.Id).ToList();

            page2Ids
                .Should().NotIntersectWith(page1Ids,
                    "page 2 should contain different items than page 1");
        }
    }

    [Fact]
    public async Task Send_CollectionRequest_WithTwentyItems_Should_ReturnUpToTwentyColors()
    {
        // Arrange
        var queryRequest = CreateQueryRequest(ItemQuantitySelection.Twenty, "name-asc", pageIndex: 1);

        // Act
        var response = await Sender.Send(queryRequest);
        var colors = response.Value!.Items;

        // Assert
        AssertSuccessfulResponse(response);

        colors
            .Should().BeInAscendingOrder(c => c.Name, UkrainianCaseInsensitiveComparer);
        colors.Count
            .Should().BeLessOrEqualTo((int)ItemQuantitySelection.Twenty);
    }
}