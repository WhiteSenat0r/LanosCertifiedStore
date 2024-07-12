using System.Globalization;
using Application.VehicleDrivetrainTypes;
using Application.VehicleDrivetrainTypes.Queries.CollectionVehicleDrivetrainTypesQueryRequestRelated;
using Domain.Entities.VehicleRelated.TypeRelated;
using IntegrationTests.Common;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTests.VehicleDrivetrainTypes;

public sealed class VehicleDrivetrainTypeQueriesIntegrationTests(
    IntegrationTestsWebApplicationFactory factory) : IntegrationTestBase(factory)
{
    [Fact]
    public async Task Send_CollectionRequest_Should_ReturnCollectionOfDrivetrainTypes()
    {
        // Arrange
        var drivetrainTypesCount = await Context
            .Set<VehicleDrivetrainType>()
            .CountAsync();

        var filteringRequestParameters = new VehicleDrivetrainTypeFilteringRequestParameters
        {
            SortingType = "name-asc",
            PageIndex = 1
        };

        var queryRequest = new CollectionVehicleDrivetrainTypesQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var drivetrainTypes = response.Value!.Items;

        // Assert
        response.Error
            .Should().BeNull();
        response.IsSuccess
            .Should().BeTrue();

        drivetrainTypes.Should().BeInAscendingOrder(
            b => b.Name,
            StringComparer.Create(new CultureInfo("uk-UA"), ignoreCase: true));
        drivetrainTypes.Count
            .Should().Be(drivetrainTypesCount);
    }
}