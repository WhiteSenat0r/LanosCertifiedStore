﻿using System.Globalization;
using IntegrationTests.Common;
using LanosCertifiedStore.Application.LocationTowns;
using LanosCertifiedStore.Application.LocationTowns.Queries.LocationTownsRelated.CollectionLocationTownsQueryRequestRelated;
using LanosCertifiedStore.Application.LocationTowns.Queries.LocationTownsRelated.CountLocationTownsQueryRelated;
using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.LocationRelated;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTests.LocationTowns;

public sealed class LocationTownQueriesIntegrationTests(
    IntegrationTestsWebApplicationFactory factory) : IntegrationTestBase(factory)
{
    [Fact]
    public async Task Send_CollectionRequest_Should_ReturnCollectionOfLocationTowns()
    {
        // Arrange
        var filteringRequestParameters = new VehicleLocationTownFilteringRequestParameters
        {
            ItemQuantity = ItemQuantitySelection.Ten,
            SortingType = "name-asc",
            PageIndex = 1
        };
        var queryRequest = new CollectionLocationTownsQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var towns = response.Value!.Items;

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();

        towns
            .Should().BeInAscendingOrder(b => b.Name, 
                StringComparer.Create(new CultureInfo("uk-UA"), ignoreCase: true));
        towns.Count
            .Should().BeLessOrEqualTo((int)ItemQuantitySelection.Ten);
    }
    
    [Fact]
    public async Task Send_CountRequest_ShouldReturn_TotalAndFilteredTownsCount()
    {
        var locationRegion = await Context.Set<VehicleLocationRegion>().FirstAsync();
        var locationTownType = await Context.Set<VehicleLocationTownType>().FirstAsync();
        
        var totalTownsCount = await Context.Set<VehicleLocationTown>().CountAsync();
        var filteredTownsCount = await Context.Set<VehicleLocationTown>()
            .CountAsync(t => t.LocationRegionId.Equals(locationRegion.Id) &&
                             t.LocationTownTypeId.Equals(locationTownType.Id));

        var requestParameters = new VehicleLocationTownFilteringRequestParameters
        {
            LocationRegionId = locationRegion.Id,
            LocationTownTypeId = locationTownType.Id
        };
        
        var queryRequest = new CountLocationTownsQueryRequest(requestParameters);

        // Act
        var response = await Sender.Send(queryRequest);

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();
        response.Value!.TotalItemsCount
            .Should().Be(totalTownsCount);
        response.Value!.FilteredItemsCount
            .Should().Be(filteredTownsCount);
    }
}