using IntegrationTests.Common;
using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.Vehicles;
using LanosCertifiedStore.Application.Vehicles.Queries.CountVehiclesQueryRelated;
using LanosCertifiedStore.Application.Vehicles.Queries.VehicleDetailsQueryRelated;
using LanosCertifiedStore.Application.Vehicles.Queries.VehiclesQueryRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTests.Vehicles;

public sealed class VehicleQueriesIntegrationTests(
    IntegrationTestsWebApplicationFactory factory) : IntegrationTestBase(factory)
{
    [Fact]
    public async Task Send_CollectionRequest_Should_ReturnCollectionOfVehicles()
    {
        // Arrange
        var filteringRequestParameters = new VehicleFilteringRequestParameters
        {
            ItemQuantity = ItemQuantitySelection.Ten,
            SortingType = "price-asc",
            PageIndex = 1
        };
        var queryRequest = new VehiclesQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var vehicles = response.Value!.Items;

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();

        vehicles
            .Should().BeInAscendingOrder(v => v.Price);
        vehicles.Count
            .Should().BeLessOrEqualTo((int)ItemQuantitySelection.Ten);
        vehicles.Count
            .Should().BeGreaterThan(0);
    }

    [Fact]
    public async Task Send_CollectionRequestFilteredByBrand_Should_ReturnFilteredVehicles()
    {
        // Arrange
        var brandName = "Toyota";
        var expectedVehiclesCount = await Context
            .Set<Vehicle>()
            .Include(v => v.VehicleBrand)
            .Where(v => v.VehicleBrand.Name == brandName)
            .AsNoTracking()
            .CountAsync();

        var filteringRequestParameters = new VehicleFilteringRequestParameters
        {
            Brand = brandName,
            ItemQuantity = ItemQuantitySelection.Twenty,
            SortingType = "price-asc",
            PageIndex = 1
        };
        var queryRequest = new VehiclesQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var vehicles = response.Value!.Items;

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();

        vehicles.Count
            .Should().Be(expectedVehiclesCount);
        vehicles
            .Should().AllSatisfy(v => v.VehicleBrand.Should().Be(brandName));
    }

    [Fact]
    public async Task Send_CollectionRequestFilteredByType_Should_ReturnFilteredVehicles()
    {
        // Arrange
        var typeName = "Легковик";
        var expectedVehiclesCount = await Context
            .Set<Vehicle>()
            .Include(v => v.VehicleType)
            .Where(v => v.VehicleType.Name == typeName)
            .AsNoTracking()
            .CountAsync();

        var filteringRequestParameters = new VehicleFilteringRequestParameters
        {
            Type = typeName,
            ItemQuantity = ItemQuantitySelection.Twenty,
            SortingType = "price-desc",
            PageIndex = 1
        };
        var queryRequest = new VehiclesQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var vehicles = response.Value!.Items;

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();

        vehicles.Count
            .Should().Be(expectedVehiclesCount);
        vehicles
            .Should().BeInDescendingOrder(v => v.Price);
        vehicles
            .Should().AllSatisfy(v => v.VehicleType.Should().Be(typeName));
    }

    [Fact]
    public async Task Send_CollectionRequestFilteredByPriceRange_Should_ReturnFilteredVehicles()
    {
        // Arrange
        var lowerPriceLimit = 25000m;
        var upperPriceLimit = 35000m;

        var expectedVehicles = await Context
            .Set<Vehicle>()
            .Where(v => v.Price >= lowerPriceLimit && v.Price <= upperPriceLimit)
            .AsNoTracking()
            .ToListAsync();

        var filteringRequestParameters = new VehicleFilteringRequestParameters
        {
            LowerPriceLimit = lowerPriceLimit,
            UpperPriceLimit = upperPriceLimit,
            ItemQuantity = ItemQuantitySelection.Twenty,
            SortingType = "price-asc",
            PageIndex = 1
        };
        var queryRequest = new VehiclesQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var vehicles = response.Value!.Items;

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();

        vehicles.Count
            .Should().Be(expectedVehicles.Count);
        vehicles
            .Should().AllSatisfy(v =>
            {
                v.Price.Should().BeGreaterOrEqualTo(lowerPriceLimit);
                v.Price.Should().BeLessOrEqualTo(upperPriceLimit);
            });
    }

    [Fact]
    public async Task Send_CollectionRequestWithMultipleFilters_Should_ReturnFilteredVehicles()
    {
        // Arrange
        var brandName = "Ford";
        var upperPriceLimit = 50000m;

        var expectedVehicles = await Context
            .Set<Vehicle>()
            .Include(v => v.VehicleBrand)
            .Where(v => v.VehicleBrand.Name == brandName && v.Price <= upperPriceLimit)
            .AsNoTracking()
            .ToListAsync();

        var filteringRequestParameters = new VehicleFilteringRequestParameters
        {
            Brand = brandName,
            UpperPriceLimit = upperPriceLimit,
            ItemQuantity = ItemQuantitySelection.Twenty,
            SortingType = "price-asc",
            PageIndex = 1
        };
        var queryRequest = new VehiclesQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var vehicles = response.Value!.Items;

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();

        vehicles.Count
            .Should().Be(expectedVehicles.Count);
        vehicles
            .Should().AllSatisfy(v =>
            {
                v.VehicleBrand.Should().Be(brandName);
                v.Price.Should().BeLessOrEqualTo(upperPriceLimit);
            });
    }

    [Fact]
    public async Task Send_CollectionRequestWithNoMatchingFilters_Should_ReturnEmptyCollection()
    {
        // Arrange
        var filteringRequestParameters = new VehicleFilteringRequestParameters
        {
            Brand = "NonExistentBrand",
            ItemQuantity = ItemQuantitySelection.Twenty,
            SortingType = "price-asc",
            PageIndex = 1
        };
        var queryRequest = new VehiclesQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var vehicles = response.Value!.Items;

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();

        vehicles.Count
            .Should().Be(0);
    }

    [Fact]
    public async Task Send_SingleRequest_Should_ReturnSingleVehicle()
    {
        // Arrange
        var vehicle = await Context
            .Set<Vehicle>()
            .AsNoTracking()
            .FirstAsync();

        var queryRequest = new VehicleSingleQueryRequest(vehicle.Id);

        // Act
        var result = await Sender.Send(queryRequest);

        // Assert
        result.IsSuccess
            .Should().BeTrue();
        result.Error
            .Should().Be(Error.None);

        result.Value!.Price
            .Should().Be(vehicle.Price);
        result.Value!.ProductionYear
            .Should().Be(vehicle.ProductionYear);
        result.Value!.Mileage
            .Should().Be(vehicle.Mileage);
    }

    [Fact]
    public async Task Send_SingleRequestWithNonExistingId_Should_ReturnError()
    {
        // Arrange
        var vehicleId = Guid.Empty;

        var queryRequest = new VehicleSingleQueryRequest(vehicleId);

        // Act
        var result = await Sender.Send(queryRequest);

        // Assert
        result.IsSuccess
            .Should().BeFalse();
        result.Error
            .Should().BeEquivalentTo(Error.NotFound(vehicleId));

        result.Value!
            .Should().BeNull();
    }

    [Fact]
    public async Task Send_CountRequest_ShouldReturn_VehiclesCount()
    {
        // Arrange
        var totalVehiclesCount = await Context
            .Set<Vehicle>()
            .CountAsync();

        var filteringRequestParameters = new VehicleFilteringRequestParameters
        {
            SortingType = "price-asc",
            PageIndex = 1
        };

        var request = new CountVehiclesQueryRequest(filteringRequestParameters);

        // Act
        var result = await Sender.Send(request);

        // Assert
        result.IsSuccess
            .Should().BeTrue();
        result.Error
            .Should().Be(Error.None);

        result.Value!.TotalItemsCount
            .Should().Be(totalVehiclesCount);
        result.Value!.FilteredItemsCount
            .Should().Be(totalVehiclesCount);
    }

    [Fact]
    public async Task Send_CountRequestFilteredByBrand_ShouldReturn_FilteredVehiclesCount()
    {
        // Arrange
        var brandName = "Honda";
        var totalVehiclesCount = await Context
            .Set<Vehicle>()
            .CountAsync();

        var filteredVehiclesCount = await Context
            .Set<Vehicle>()
            .Include(v => v.VehicleBrand)
            .Where(v => v.VehicleBrand.Name == brandName)
            .CountAsync();

        var filteringRequestParameters = new VehicleFilteringRequestParameters
        {
            Brand = brandName,
            SortingType = "price-asc",
            PageIndex = 1
        };

        var request = new CountVehiclesQueryRequest(filteringRequestParameters);

        // Act
        var result = await Sender.Send(request);

        // Assert
        result.IsSuccess
            .Should().BeTrue();
        result.Error
            .Should().Be(Error.None);

        result.Value!.FilteredItemsCount
            .Should().Be(filteredVehiclesCount);
        result.Value!.TotalItemsCount
            .Should().Be(totalVehiclesCount);
    }

    [Fact]
    public async Task Send_CountRequestFilteredByPriceRange_ShouldReturn_FilteredVehiclesCount()
    {
        // Arrange
        var lowerPriceLimit = 20000m;
        var upperPriceLimit = 40000m;

        var totalVehiclesCount = await Context
            .Set<Vehicle>()
            .CountAsync();

        var filteredVehiclesCount = await Context
            .Set<Vehicle>()
            .Where(v => v.Price >= lowerPriceLimit && v.Price <= upperPriceLimit)
            .CountAsync();

        var filteringRequestParameters = new VehicleFilteringRequestParameters
        {
            LowerPriceLimit = lowerPriceLimit,
            UpperPriceLimit = upperPriceLimit,
            SortingType = "price-asc",
            PageIndex = 1
        };

        var request = new CountVehiclesQueryRequest(filteringRequestParameters);

        // Act
        var result = await Sender.Send(request);

        // Assert
        result.IsSuccess
            .Should().BeTrue();
        result.Error
            .Should().Be(Error.None);

        result.Value!.FilteredItemsCount
            .Should().Be(filteredVehiclesCount);
        result.Value!.TotalItemsCount
            .Should().Be(totalVehiclesCount);
    }
}
