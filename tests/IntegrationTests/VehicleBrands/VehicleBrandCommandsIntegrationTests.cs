﻿using IntegrationTests.Common;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.VehicleBrands.Commands.CreateVehicleBrandRelated;
using LanosCertifiedStore.Application.VehicleBrands.Commands.UpdateVehicleBrandRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTests.VehicleBrands;

public sealed class VehicleBrandCommandsIntegrationTests(
    IntegrationTestsWebApplicationFactory factory) : IntegrationTestBase(factory)
{
    [Fact]
    public async Task Send_CreateRequest_Should_AddNewBrandIfRequestIsValid()
    {
        // Arrange
        const string newBrandName = "Name";
        var commandRequest = new CreateVehicleBrandCommandRequest(newBrandName);

        // Act
        var response = await Sender.Send(commandRequest);
        var createdBrand = await Context.FindAsync<VehicleBrand>(response.Value);

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();
        response.Value
            .Should().NotBeEmpty();

        createdBrand
            .Should().NotBeNull();
        createdBrand!.Name
            .Should().Be(newBrandName);
    }

    [Fact]
    public async Task Send_UpdateRequest_Should_UpdateExistingBrandIfRequestIsValid()
    {
        // Arrange
        var brand = await Context.Set<VehicleBrand>().FirstAsync();
        var previousName = new string(brand.Name);
        var commandRequest = new UpdateVehicleBrandCommandRequest(brand.Id, brand.Id.ToString());

        // Act
        var response = await Sender.Send(commandRequest);
        var updatedBrand = await Context.FindAsync<VehicleBrand>(brand.Id);

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();

        updatedBrand
            .Should().NotBeNull();
        updatedBrand!.Name
            .Should().NotBe(previousName);
        updatedBrand!.Name
            .Should().Be(brand.Id.ToString());
    }

    [Fact]
    public async Task UpdateVehicleBrandCommandRequestHandler_Should_NotUpdateNonExistingBrand()
    {
        // Arrange
        var commandRequest = new UpdateVehicleBrandCommandRequest(Guid.Empty, string.Empty);

        // Act
        var response = await Sender.Send(commandRequest);

        // Assert
        response.Error
            .Should().NotBeNull();
        response.IsSuccess
            .Should().NotBe(true);
    }
}