using System.Globalization;
using Application.VehicleModels;
using Application.VehicleModels.Queries.CollectionVehicleModelsQueryRelated;
using Domain.Entities.VehicleRelated;
using IntegrationTests.Common;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTests.VehicleModels;

public sealed class VehicleModelQueriesIntegrationTests(
    IntegrationTestsWebApplicationFactory factory) : IntegrationTestBase(factory)
{
    /* TODO THIS DOESN'T WORK YET BECAUSE OF EXCEPTION THROWN IN SEEDING
        LOCATION ARE NOT BEING SEEDED SINCE FILE CAN'T BE ACCESSED (COOL)
         AND BECAUSE OF THAT SeedBrands() DOESN'T EVEN TRIGGER
    */
    [Fact]
    public async Task Send_CollectionRequest_Should_ReturnCollectionOfModels()
    {
        // Arrange
        var modelsCount = await Context
            .Set<VehicleModel>()
            .ToListAsync();

        var filteringRequestParameters = new VehicleModelFilteringRequestParameters
        {
            SortingType = "name-asc",
            PageIndex = 1
        };

        var queryRequest = new CollectionVehicleModelsQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var models = response.Value!.Items;

        // Assert
        response.Error
            .Should().BeNull();
        response.IsSuccess
            .Should().BeTrue();

        models.Should().BeInAscendingOrder(
            b => b.Name,
            StringComparer.Create(new CultureInfo("uk-UA"), ignoreCase: true));
        models.Count
            .Should().Be(modelsCount.Count);
    }
}