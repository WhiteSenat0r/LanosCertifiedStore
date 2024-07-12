using System.Globalization;
using Application.VehicleTypes;
using Application.VehicleTypes.Queries.CollectionVehicleTypesQueryRelated;
using Domain.Entities.VehicleRelated.TypeRelated;
using IntegrationTests.Common;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTests.VehicleTypes;

public sealed class VehicleTypeQueriesIntegrationTests(
    IntegrationTestsWebApplicationFactory factory) : IntegrationTestBase(factory)
{
    [Fact]
    public async Task Send_CollectionRequest_Should_ReturnCollectionOfTypes()
    {
        // Arrange
        var typesCount = await Context
            .Set<VehicleType>()
            .CountAsync();

        var filteringRequestParameters = new VehicleTypeFilteringRequestParameters
        {
            SortingType = "name-asc",
            PageIndex = 1
        };

        var queryRequest = new CollectionVehicleTypesQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var types = response.Value!.Items;

        // Assert
        response.Error
            .Should().BeNull();
        response.IsSuccess
            .Should().BeTrue();

        types.Should().BeInAscendingOrder(
            b => b.Name,
            StringComparer.Create(new CultureInfo("uk-UA"), ignoreCase: true));
        types.Count
            .Should().Be(typesCount);
    }
}