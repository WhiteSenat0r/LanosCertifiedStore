using System.Globalization;
using Application.VehicleTransmissionTypes;
using Application.VehicleTransmissionTypes.Queries.CollectionVehicleTransmissionTypesQueryRelated;
using Domain.Entities.VehicleRelated.TypeRelated;
using IntegrationTests.Common;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTests.VehicleTransmissionTypes;

public sealed class VehicleTransmissionTypeQueriesIntegrationTests(
    IntegrationTestsWebApplicationFactory factory) : IntegrationTestBase(factory)
{
    [Fact]
    public async Task Send_CollectionRequest_Should_ReturnCollectionOfTransmissionTypes()
    {
        // Arrange
        var transmissionTypesCount = await Context
            .Set<VehicleTransmissionType>()
            .CountAsync();

        var filteringRequestParameters = new VehicleTransmissionTypeFilteringRequestParameters
        {
            SortingType = "name-asc",
            PageIndex = 1
        };

        var queryRequest = new CollectionVehicleTransmissionTypesQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var transmissionTypes = response.Value!.Items;

        // Assert
        response.Error
            .Should().BeNull();
        response.IsSuccess
            .Should().BeTrue();

        transmissionTypes.Should().BeInAscendingOrder(
            b => b.Name,
            StringComparer.Create(new CultureInfo("uk-UA"), ignoreCase: true));
        transmissionTypes.Count
            .Should().Be(transmissionTypesCount);
    }
}