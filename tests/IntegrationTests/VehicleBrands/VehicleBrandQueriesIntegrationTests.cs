using IntegrationTests.Common;
using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.VehicleBrands;
using LanosCertifiedStore.Application.VehicleBrands.Queries.CollectionVehicleBrandsQueryRelated;
using LanosCertifiedStore.Application.VehicleBrands.Queries.CountVehicleBrandsQueryRelated;
using LanosCertifiedStore.Application.VehicleBrands.Queries.SingleVehicleBrandQueryRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTests.VehicleBrands;

public sealed class VehicleBrandQueriesIntegrationTests(
    IntegrationTestsWebApplicationFactory factory) : IntegrationTestBase(factory)
{
    [Fact]
    public async Task Send_CollectionRequest_Should_ReturnCollectionOfBrands()
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
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();

        brands
            .Should().BeInAscendingOrder(b => b.Name);
        brands.Count
            .Should().BeLessOrEqualTo((int)ItemQuantitySelection.Ten);
    }

    [Fact]
    public async Task Send_SingleRequest_Should_ReturnSingleBrand()
    {
        // Arrange
        var brand = await Context.Set<VehicleBrand>().FirstAsync();
        var queryRequest = new SingleVehicleBrandQueryRequest(brand.Id);

        // Act
        var response = await Sender.Send(queryRequest);

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();
        response.Value!.Id
            .Should().Be(brand.Id);
        response.Value!.Name
            .Should().Be(brand.Name);
    }

    [Fact]
    public async Task Send_SingleRequest_WithInvalidId_ShouldReturn_FailureResult()
    {
        // Arrange
        var queryRequest = new SingleVehicleBrandQueryRequest(Guid.Empty);

        // Act
        var response = await Sender.Send(queryRequest);

        // Assert
        response.Error
            .Should().NotBeNull();
        response.IsSuccess
            .Should().BeFalse();
    }

    [Fact]
    public async Task Send_CountRequest_ShouldReturn_TotalAndFilteredBrandsCount()
    {
        // Arrange
        var brandsCount = await Context.Set<VehicleBrand>().CountAsync();
        var queryRequest = new CountVehicleBrandsQueryRequest(new VehicleBrandFilteringRequestParameters());

        // Act
        var response = await Sender.Send(queryRequest);

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();
        response.Value!.TotalItemsCount
            .Should().Be(brandsCount);
        response.Value!.FilteredItemsCount
            .Should().Be(brandsCount);
    }
}