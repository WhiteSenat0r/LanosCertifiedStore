using System.Globalization;
using IntegrationTests.Common;
using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.VehicleColors;
using LanosCertifiedStore.Application.VehicleColors.Queries.CollectionVehicleColorsQueryRequestRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using Microsoft.EntityFrameworkCore;

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
    public async Task Send_CollectionRequest_WithDescendingSorting_Should_ReturnColorsInDescendingOrder()
    {
        // Arrange
        var queryRequest = CreateQueryRequest(ItemQuantitySelection.Ten, "name-desc", 1);

        // Act
        var (response, colors) = await ExecuteQuery(queryRequest);

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();

        colors
            .Should().BeInDescendingOrder(c => c.Name,
                StringComparer.Create(new CultureInfo("uk-UA"), ignoreCase: true));
    }

    [Fact]
    public async Task Send_CollectionRequest_WithDifferentPageSizes_Should_ReturnCorrectNumberOfColors()
    {
        // Arrange
        var queryRequestFive = CreateQueryRequest(ItemQuantitySelection.Five, "name-asc", 1);

        // Act
        var (responseFive, colorsFive) = await ExecuteQuery(queryRequestFive);

        // Assert
        responseFive.IsSuccess
            .Should().BeTrue();
        colorsFive.Count
            .Should().BeLessOrEqualTo((int)ItemQuantitySelection.Five);
    }

    [Fact]
    public async Task Send_CollectionRequest_WithMultiplePages_Should_ReturnDifferentColors()
    {
        // Arrange
        var totalColors = await Context.Set<VehicleColor>().CountAsync();

        // Skip test if not enough data for pagination
        if (totalColors <= (int)ItemQuantitySelection.Five)
        {
            return;
        }

        var queryRequestPage1 = CreateQueryRequest(ItemQuantitySelection.Five, "name-asc", 1);
        var queryRequestPage2 = CreateQueryRequest(ItemQuantitySelection.Five, "name-asc", 2);

        // Act
        var (responsePage1, colorsPage1) = await ExecuteQuery(queryRequestPage1);
        var (responsePage2, colorsPage2) = await ExecuteQuery(queryRequestPage2);

        // Assert
        responsePage1.IsSuccess
            .Should().BeTrue();
        responsePage2.IsSuccess
            .Should().BeTrue();

        // Pages should have different colors (no overlap)
        colorsPage1.Select(c => c.Id)
            .Should().NotIntersectWith(colorsPage2.Select(c => c.Id));
    }

    [Fact]
    public async Task Send_CollectionRequest_Should_ReturnColorsWithValidHexCodes()
    {
        // Arrange
        var queryRequest = CreateQueryRequest(ItemQuantitySelection.Ten, "name-asc", 1);

        // Act
        var (response, colors) = await ExecuteQuery(queryRequest);

        // Assert
        response.IsSuccess
            .Should().BeTrue();

        colors
            .Should().NotBeEmpty();

        // All colors should have valid hex color codes
        colors
            .Should().OnlyContain(c => !string.IsNullOrWhiteSpace(c.HexValue));

        colors
            .Should().OnlyContain(c => c.HexValue.StartsWith('#'));
    }

    [Fact]
    public async Task Send_CollectionRequest_WithMaxPageSize_Should_ReturnCorrectNumberOfColors()
    {
        // Arrange
        var queryRequest = CreateQueryRequest(ItemQuantitySelection.Hundred, "name-asc", 1);

        // Act
        var (response, colors) = await ExecuteQuery(queryRequest);

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();

        colors.Count
            .Should().BeLessOrEqualTo((int)ItemQuantitySelection.Hundred);
    }

    [Fact]
    public async Task Send_CollectionRequest_Should_ReturnColorsWithUniqueIds()
    {
        // Arrange
        var queryRequest = CreateQueryRequest(ItemQuantitySelection.Twenty, "name-asc", 1);

        // Act
        var (response, colors) = await ExecuteQuery(queryRequest);

        // Assert
        response.IsSuccess
            .Should().BeTrue();

        // All color IDs should be unique
        colors.Select(c => c.Id)
            .Should().OnlyHaveUniqueItems();
    }

    [Fact]
    public async Task Send_CollectionRequest_Should_MatchDatabaseColorCount()
    {
        // Arrange
        var totalColorsInDb = await Context.Set<VehicleColor>().CountAsync();

        var queryRequest = CreateQueryRequest(ItemQuantitySelection.Hundred, "name-asc", 1);

        // Act
        var (response, colors) = await ExecuteQuery(queryRequest);

        // Assert
        response.IsSuccess
            .Should().BeTrue();

        // If database has fewer colors than page size, counts should match
        if (totalColorsInDb <= (int)ItemQuantitySelection.Hundred)
        {
            colors.Count
                .Should().Be(totalColorsInDb);
        }
    }

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

    private async Task<(Result<PaginationResult<VehicleColorDto>> response, List<VehicleColorDto> colors)> ExecuteQuery(
        CollectionVehicleColorsQueryRequest queryRequest)
    {
        var response = await Sender.Send(queryRequest);
        return (response, response.Value!.Items);
    }
}