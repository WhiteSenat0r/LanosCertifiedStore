using System.Globalization;
using Application.VehicleEngineTypes;
using Application.VehicleEngineTypes.Queries.CollectionVehicleEngineTypesQueryRelated;
using Domain.Entities.VehicleRelated.TypeRelated;
using IntegrationTests.Common;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTests.VehicleEngineTypes;

public sealed class VehicleEngineTypeQueriesIntegrationTests(
    IntegrationTestsWebApplicationFactory factory) : IntegrationTestBase(factory)
{
    [Fact]
    public async Task Send_CollectionRequest_Should_ReturnCollectionOfEngineTypes()
    {
        // Arrange
        var engineTypeCount = await Context
            .Set<VehicleEngineType>()
            .CountAsync();

        var filteringRequestParameters = new VehicleEngineTypeFilteringRequestParameters
        {
            SortingType = "name-asc",
            PageIndex = 1
        };

        var queryRequest = new CollectionVehicleEngineTypesQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var engineType = response.Value!.Items;

        // Assert
        response.Error
            .Should().BeNull();
        response.IsSuccess
            .Should().BeTrue();

        engineType.Should().BeInAscendingOrder(
            b => b.Name,
            StringComparer.Create(new CultureInfo("uk-UA"), ignoreCase: true));
        engineType.Count
            .Should().Be(engineTypeCount);
    }
}