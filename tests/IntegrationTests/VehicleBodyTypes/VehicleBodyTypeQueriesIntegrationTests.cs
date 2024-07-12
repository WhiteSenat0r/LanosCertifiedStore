using System.Globalization;
using Application.VehicleBodyTypes;
using Application.VehicleBodyTypes.Queries.CollectionVehicleBodyTypesQueryRelated;
using Domain.Entities.VehicleRelated.TypeRelated;
using IntegrationTests.Common;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTests.VehicleBodyTypes;

public sealed class VehicleBodyTypeQueriesIntegrationTests(
    IntegrationTestsWebApplicationFactory factory) : IntegrationTestBase(factory)
{
    [Fact]
    public async Task Send_CollectionRequest_Should_ReturnCollectionOfBodyTypes()
    {
        // Arrange
        var bodyTypesCount = await Context
            .Set<VehicleBodyType>()
            .CountAsync();

        var filteringRequestParameters = new VehicleBodyTypeFilteringRequestParameters
        {
            SortingType = "name-asc",
            PageIndex = 1
        };

        var queryRequest = new CollectionVehicleBodyTypesQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var bodyTypes = response.Value!.Items;

        // Assert
        response.Error
            .Should().BeNull();
        response.IsSuccess
            .Should().BeTrue();

        bodyTypes.Should().BeInAscendingOrder(
            b => b.Name,
            StringComparer.Create(new CultureInfo("uk-UA"), ignoreCase: true));
        bodyTypes.Count
            .Should().Be(bodyTypesCount);
    }
}