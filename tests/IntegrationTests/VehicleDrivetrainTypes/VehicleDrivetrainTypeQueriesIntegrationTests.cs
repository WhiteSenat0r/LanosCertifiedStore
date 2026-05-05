using IntegrationTests.Common;
using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.VehicleDrivetrainTypes;
using LanosCertifiedStore.Application.VehicleDrivetrainTypes.Queries.CollectionVehicleDrivetrainTypesQueryRequestRelated;

namespace IntegrationTests.VehicleDrivetrainTypes;

public sealed class VehicleDrivetrainTypeQueriesIntegrationTests(
    IntegrationTestsWebApplicationFactory factory) : IntegrationTestBase(factory)
{
    [Fact]
    public async Task Send_CollectionRequest_Should_ReturnCollectionOfDrivetrainTypes()
    {
        // Arrange
        var filteringRequestParameters = new VehicleDrivetrainTypeFilteringRequestParameters
        {
            ItemQuantity = ItemQuantitySelection.Ten,
            SortingType = "name-asc",
            PageIndex = 1
        };
        var queryRequest = new CollectionVehicleDrivetrainTypesQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var drivetrainTypes = response.Value!.Items;

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();

        drivetrainTypes
            .Should().BeInAscendingOrder(b => b.Name);
        drivetrainTypes.Count
            .Should().BeLessOrEqualTo((int)ItemQuantitySelection.Ten);
    }

    [Fact]
    public async Task Send_CollectionRequest_WithDescendingSort_Should_ReturnDrivetrainTypesInDescendingOrder()
    {
        // Arrange
        var filteringRequestParameters = new VehicleDrivetrainTypeFilteringRequestParameters
        {
            ItemQuantity = ItemQuantitySelection.Ten,
            SortingType = "name-desc",
            PageIndex = 1
        };
        var queryRequest = new CollectionVehicleDrivetrainTypesQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var drivetrainTypes = response.Value!.Items;

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();

        drivetrainTypes
            .Should().BeInDescendingOrder(b => b.Name);
        drivetrainTypes.Count
            .Should().BeLessOrEqualTo((int)ItemQuantitySelection.Ten);
    }

    [Fact]
    public async Task Send_CollectionRequest_WithPagination_Should_ReturnCorrectPage()
    {
        // Arrange
        var filteringRequestParameters = new VehicleDrivetrainTypeFilteringRequestParameters
        {
            ItemQuantity = ItemQuantitySelection.Five,
            SortingType = "name-asc",
            PageIndex = 2
        };
        var queryRequest = new CollectionVehicleDrivetrainTypesQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var drivetrainTypes = response.Value!.Items;

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();

        drivetrainTypes
            .Should().BeInAscendingOrder(b => b.Name);
        drivetrainTypes.Count
            .Should().BeLessOrEqualTo((int)ItemQuantitySelection.Five);
    }

    [Fact]
    public async Task Send_CollectionRequest_WithHighPageIndex_Should_HandleGracefully()
    {
        // Arrange
        var filteringRequestParameters = new VehicleDrivetrainTypeFilteringRequestParameters
        {
            ItemQuantity = ItemQuantitySelection.Ten,
            SortingType = "name-asc",
            PageIndex = 100
        };
        var queryRequest = new CollectionVehicleDrivetrainTypesQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var drivetrainTypes = response.Value!.Items;

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();

        drivetrainTypes.Count
            .Should().BeGreaterOrEqualTo(0);
    }

    [Fact]
    public async Task Send_CollectionRequest_WithDifferentItemQuantities_Should_RespectLimit()
    {
        // Arrange
        var filteringRequestParameters = new VehicleDrivetrainTypeFilteringRequestParameters
        {
            ItemQuantity = ItemQuantitySelection.Twenty,
            SortingType = "name-asc",
            PageIndex = 1
        };
        var queryRequest = new CollectionVehicleDrivetrainTypesQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var drivetrainTypes = response.Value!.Items;

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();

        drivetrainTypes.Count
            .Should().BeLessOrEqualTo((int)ItemQuantitySelection.Twenty);
    }
}