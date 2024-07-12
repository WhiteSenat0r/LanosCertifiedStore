using Application.Shared.RequestParamsRelated;
using Application.VehicleBrands;
using Application.VehicleBrands.Queries.CollectionVehicleBrandsQueryRelated;
using Application.VehicleBrands.Queries.CountVehicleBrandsQueryRelated;
using Application.VehicleBrands.Queries.SingleVehicleBrandQueryRelated;
using Domain.Entities.VehicleRelated;
using IntegrationTests.Common;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTests.VehicleBrands;

public sealed class VehicleBrandQueryIntegrationTests(
    IntegrationTestsWebApplicationFactory factory) : IntegrationTestBase(factory)
{
    [Fact]
    public async Task CollectionVehicleBrandsQueryRequestHandler_WithAppliedParameters_ShouldReturn_BrandCollection()
    {
        // Arrange
        var filteringRequestParameters = new VehicleBrandFilteringRequestParameters
        {
            ItemQuantity = ItemQuantitySelection.Ten,
            SortingType = "name-asc",
            PageIndex = 2
        };
        var queryRequest = new CollectionVehicleBrandsQueryRequest(filteringRequestParameters);

        // Act
        var response = await Sender.Send(queryRequest);
        var brands = response.Value!.Items;

        // Assert
        response.Error.Should().BeNull();
        response.IsSuccess.Should().BeTrue();

        brands.Should().BeInAscendingOrder(b => b.Name);
        brands.Count.Should().Be((int)ItemQuantitySelection.Ten);
    }
    
    [Fact]
    public async Task SingleVehicleBrandQueryRequestHandler_ShouldReturn_SingleBrand()
    {
        // Arrange
        var brand = await Context.Set<VehicleBrand>().FirstAsync();
        var queryRequest = new SingleVehicleBrandQueryRequest(brand.Id);

        // Act
        var response = await Sender.Send(queryRequest);

        // Assert
        response.Error.Should().BeNull();
        response.IsSuccess.Should().BeTrue();
        response.Value!.Id.Should().Be(brand.Id);
        response.Value!.Name.Should().Be(brand.Name);
    }
    
    [Fact]
    public async Task SingleVehicleBrandQueryRequestHandler_WithInvalidId_ShouldReturn_FailureResult()
    {
        // Arrange
        var queryRequest = new SingleVehicleBrandQueryRequest(Guid.Empty);

        // Act
        var response = await Sender.Send(queryRequest);

        // Assert
        response.Error.Should().NotBeNull();
        response.IsSuccess.Should().NotBe(true);
    }
    
    [Fact]
    public async Task CountVehicleBrandsQueryRequestHandler_ShouldReturn_SingleBrand()
    {
        // Arrange
        var brandsCount = await Context.Set<VehicleBrand>().CountAsync();
        var queryRequest = new CountVehicleBrandsQueryRequest(new VehicleBrandFilteringRequestParameters());

        // Act
        var response = await Sender.Send(queryRequest);

        // Assert
        response.Error.Should().BeNull();
        response.IsSuccess.Should().BeTrue();
        response.Value!.TotalItemsCount.Should().Be(brandsCount);
        response.Value!.FilteredItemsCount.Should().Be(brandsCount);
    }
}