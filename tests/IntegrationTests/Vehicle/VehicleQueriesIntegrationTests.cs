using IntegrationTests.Common;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.Vehicles;
using LanosCertifiedStore.Application.Vehicles.Queries.CollectionVehiclesQueryRelated;
using LanosCertifiedStore.Application.Vehicles.Queries.CountVehiclesQueryRelated;
using LanosCertifiedStore.Application.Vehicles.Queries.SearchVehiclesQueryRelated;
using LanosCertifiedStore.Application.Vehicles.Queries.VehiclePriceRangeQueryRelated;

namespace IntegrationTests.Vehicle;

public sealed class VehicleQueriesIntegrationTests(
    IntegrationTestsWebApplicationFactory factory) : IntegrationTestBase(factory)
{
    
    [Fact]
    public async Task Send_CollectionQueryRequest_Should_ReturnFilteredVehicles()
    {
        // Arrange
        var filteringParameters = new VehicleFilteringRequestParameters();

        var queryRequest = new CollectionVehiclesQueryRequest(filteringParameters);

        // Act
        var response = await Sender.Send(queryRequest);

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();
        response.Value.Items
            .Should().NotBeEmpty();
    }

    [Fact]
    public async Task Send_CollectionQueryRequest_Should_ReturnEmptyResultIfNoMatch()
    {
        // Arrange
        var filteringParameters = new VehicleFilteringRequestParameters
        {
            BrandId = Guid.NewGuid(),
            PageIndex = 1
        };

        var queryRequest = new CollectionVehiclesQueryRequest(filteringParameters);

        // Act
        var response = await Sender.Send(queryRequest);

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();
        response.Value.Items
            .Should().BeEmpty();
    }
    
    [Fact]
    public async Task Send_VehiclePriceRangeQueryRequest_Should_ReturnPriceRange()
    {
        // Arrange
        var requestParameters = new VehicleFilteringRequestParameters();
        var queryRequest = new VehiclePriceRangeQueryRequest(requestParameters);

        // Act
        var response = await Sender.Send(queryRequest);

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();
        response.Value
            .Should().NotBeNull();
    }

    [Fact]
    public async Task Send_VehiclePriceRangeQueryRequest_Should_ReturnDefaultIfNoVehiclesMatch()
    {
        // Arrange
        var requestParameters = new VehicleFilteringRequestParameters
        {
            BrandId = Guid.NewGuid()
        };
        var queryRequest = new VehiclePriceRangeQueryRequest(requestParameters);

        // Act
        var response = await Sender.Send(queryRequest);

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();
        response.Value
            .Should().NotBeNull();
    }
    
    [Fact]
    public async Task Send_CountVehiclesQueryRequest_Should_ReturnCorrectCount()
    {
        // Arrange
        var filteringParameters = new VehicleFilteringRequestParameters();
        var queryRequest = new CountVehiclesQueryRequest(filteringParameters);

        // Act
        var response = await Sender.Send(queryRequest);

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();
    }

    [Fact]
    public async Task Send_SearchVehiclesQueryRequest_Should_ReturnRelevantVehicles()
    {
        // Arrange
        var filteringParameters = new SearchVehicleFilteringRequestParameters
        {
            SearchTerm = "Volkswagen"
        };
        var queryRequest = new SearchVehiclesQueryRequest(filteringParameters);

        // Act
        var response = await Sender.Send(queryRequest);

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();
        response.Value.Items
            .Should().NotBeEmpty();
    }
}