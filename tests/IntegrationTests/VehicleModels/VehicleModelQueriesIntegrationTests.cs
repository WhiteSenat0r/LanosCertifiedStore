using System.Globalization;
using IntegrationTests.Common;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.VehicleModels;
using LanosCertifiedStore.Application.VehicleModels.Queries.CollectionVehicleBrandlessModelsQueryRelated;
using LanosCertifiedStore.Application.VehicleModels.Queries.CollectionVehicleModelsQueryRelated;
using LanosCertifiedStore.Application.VehicleModels.Queries.CountVehicleModelsQueryRelated;
using LanosCertifiedStore.Application.VehicleModels.Queries.SingleVehicleModelQueryRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTests.VehicleModels;

public sealed class VehicleModelQueriesIntegrationTests(
    IntegrationTestsWebApplicationFactory factory) : IntegrationTestBase(factory)
{
    [Fact]
    public async Task Send_CollectionRequest_Should_ReturnCollectionOfModels()
    {
        // Arrange
        var brandId = (await Context.Set<VehicleBrand>().FirstAsync()).Id;

        var modelsCount = await Context
            .Set<VehicleModel>()
            .Where(x => x.VehicleBrandId == brandId)
            .AsNoTracking()
            .ToListAsync();


        var filteringRequestParameters = new VehicleModelFilteringRequestParameters
        {
            VehicleBrandId = brandId,
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

    [Fact]
    public async Task Send_BrandlessCollectionRequest_Should_ReturnBrandlessCollectionOfModels()
    {
        // Arrange
        var brandId = (await Context.Set<VehicleBrand>().FirstAsync()).Id;

        var modelsCount = await Context
            .Set<VehicleModel>()
            .Where(x => x.VehicleBrandId == brandId)
            .AsNoTracking()
            .ToListAsync();


        var filteringRequestParameters = new VehicleModelFilteringRequestParameters
        {
            VehicleBrandId = brandId,
            SortingType = "name-asc",
            PageIndex = 1
        };

        var queryRequest = new CollectionBrandlessVehicleModelsQueryRequest(filteringRequestParameters);

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

    [Fact]
    public async Task Send_SingleRequest_Should_ReturnSingleModel()
    {
        // Arrange
        var vehicleModel = await Context
            .Set<VehicleModel>()
            .AsNoTracking()
            .FirstAsync();

        var queryRequest = new SingleVehicleModelQueryRequest(vehicleModel.Id);

        // Act
        var result = await Sender.Send(queryRequest);

        // Assert
        result.IsSuccess
            .Should().BeTrue();
        result.Error
            .Should().BeNull();

        result.Value!.Name
            .Should().Be(vehicleModel.Name);
    }

    [Fact]
    public async Task Send_SingleRequestWithNonExistingId_Should_ReturnError()
    {
        // Arrange
        var modelId = Guid.Empty;

        var queryRequest = new SingleVehicleModelQueryRequest(modelId);

        // Act
        var result = await Sender.Send(queryRequest);

        // Assert
        result.IsSuccess
            .Should().BeFalse();
        result.Error
            .Should().BeEquivalentTo(Error.NotFound(modelId));

        result.Value!
            .Should().BeNull();
    }

    [Fact]
    public async Task Send_CountRequest_ShouldReturn_ModelsCount()
    {
        // Arrange
        var brandId = (await Context.Set<VehicleBrand>().FirstAsync()).Id;
        
        var totalModelsCount = await Context
            .Set<VehicleModel>()
            .CountAsync();

        var filteredModelsCount = await Context
            .Set<VehicleModel>()
            .Where(m => m.VehicleBrandId == brandId)
            .CountAsync();
        
        var filteringRequestParameters = new VehicleModelFilteringRequestParameters
        {
            VehicleBrandId = brandId,
            SortingType = "name-asc",
            PageIndex = 1
        };

        var request = new CountVehicleModelsQueryRequest(filteringRequestParameters);

        // Act
        var result = await Sender.Send(request);
        
        // Assert
        result.IsSuccess
            .Should().BeTrue();
        result.Error
            .Should().BeNull();

        result.Value!.FilteredItemsCount
            .Should().Be(filteredModelsCount);
        result.Value!.TotalItemsCount
            .Should().Be(totalModelsCount);
    }
}