﻿using IntegrationTests.Common;
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
}