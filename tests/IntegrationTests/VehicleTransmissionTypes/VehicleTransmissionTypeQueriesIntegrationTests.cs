using IntegrationTests.Common;
using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.VehicleTransmissionTypes;
using LanosCertifiedStore.Application.VehicleTransmissionTypes.Queries.CollectionVehicleTransmissionTypesQueryRelated;

namespace IntegrationTests.VehicleTransmissionTypes;

public sealed class VehicleTransmissionTypeQueriesIntegrationTests(
    IntegrationTestsWebApplicationFactory factory) : IntegrationTestBase(factory)
{
    [Fact]
    public async Task Send_CollectionRequest_Should_ReturnCollectionOfTransmissionTypes()
    {
        // Arrange
        var filteringRequestParameters = new VehicleTransmissionTypeFilteringRequestParameters
        {
            ItemQuantity = ItemQuantitySelection.Ten,
            SortingType = "name-asc",
            PageIndex = 1
        };
        var queryRequest = new CollectionVehicleTransmissionTypesQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var transmissionTypes = response.Value!.Items;

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();

        transmissionTypes
            .Should().BeInAscendingOrder(b => b.Name);
        transmissionTypes.Count
            .Should().BeLessOrEqualTo((int)ItemQuantitySelection.Ten);
    }

    [Fact]
    public async Task Send_CollectionRequest_WithDescendingSort_Should_ReturnTransmissionTypesInDescendingOrder()
    {
        // Arrange
        var filteringRequestParameters = new VehicleTransmissionTypeFilteringRequestParameters
        {
            ItemQuantity = ItemQuantitySelection.Ten,
            SortingType = "name-desc",
            PageIndex = 1
        };
        var queryRequest = new CollectionVehicleTransmissionTypesQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var transmissionTypes = response.Value!.Items;

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();

        transmissionTypes
            .Should().BeInDescendingOrder(b => b.Name);
        transmissionTypes.Count
            .Should().BeLessOrEqualTo((int)ItemQuantitySelection.Ten);
    }

    [Fact]
    public async Task Send_CollectionRequest_WithPagination_Should_ReturnCorrectPage()
    {
        // Arrange
        var filteringRequestParameters = new VehicleTransmissionTypeFilteringRequestParameters
        {
            ItemQuantity = ItemQuantitySelection.Five,
            SortingType = "name-asc",
            PageIndex = 2
        };
        var queryRequest = new CollectionVehicleTransmissionTypesQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var transmissionTypes = response.Value!.Items;

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();

        transmissionTypes
            .Should().BeInAscendingOrder(b => b.Name);
        transmissionTypes.Count
            .Should().BeLessOrEqualTo((int)ItemQuantitySelection.Five);
    }

    [Fact]
    public async Task Send_CollectionRequest_WithHighPageIndex_Should_HandleGracefully()
    {
        // Arrange
        var filteringRequestParameters = new VehicleTransmissionTypeFilteringRequestParameters
        {
            ItemQuantity = ItemQuantitySelection.Ten,
            SortingType = "name-asc",
            PageIndex = 100
        };
        var queryRequest = new CollectionVehicleTransmissionTypesQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var transmissionTypes = response.Value!.Items;

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();

        transmissionTypes.Count
            .Should().BeGreaterOrEqualTo(0);
    }

    [Fact]
    public async Task Send_CollectionRequest_WithDifferentItemQuantities_Should_RespectLimit()
    {
        // Arrange
        var filteringRequestParameters = new VehicleTransmissionTypeFilteringRequestParameters
        {
            ItemQuantity = ItemQuantitySelection.Twenty,
            SortingType = "name-asc",
            PageIndex = 1
        };
        var queryRequest = new CollectionVehicleTransmissionTypesQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var transmissionTypes = response.Value!.Items;

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();

        transmissionTypes.Count
            .Should().BeLessOrEqualTo((int)ItemQuantitySelection.Twenty);
    }

}