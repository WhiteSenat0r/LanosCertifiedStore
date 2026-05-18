using IntegrationTests.Common;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.VehicleModels.Commands.CreateVehicleModelRelated;
using LanosCertifiedStore.Application.VehicleModels.Commands.UpdateVehicleModelRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTests.VehicleModels;

public sealed class VehicleModelCommandsIntegrationTests(
    IntegrationTestsWebApplicationFactory factory) : IntegrationTestBase(factory)
{
    private const string ModelName = "test";
    
    [Fact]
    public async Task Send_CreateRequest_Should_AddNewModelIfRequestIsValid()
    {
        // Arrange
        var commandRequest = await InstantiateValidCreateRequest();

        // Act
        var response = await Sender.Send(commandRequest);
        var createdModel = await Context.FindAsync<VehicleModel>(response.Value);

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();
        response.Value
            .Should().NotBeEmpty();

        createdModel
            .Should().NotBeNull();
        createdModel!.Name
            .Should().Be(commandRequest.Name);
    }
    
    [Fact]
    public async Task Send_CreateRequest_ShouldNot_AddNewModelIfRequestIsInvalid()
    {
        // Arrange
        var commandRequest = new CreateVehicleModelCommandRequest(
            string.Empty,
            Guid.Empty,
            Guid.Empty,
            default,
            default,
            [], [], [], []
        );

        // Act
        var response = await Sender.Send(commandRequest);

        // Assert
        response.Error
            .Should().NotBeNull();
        response.IsSuccess
            .Should().BeFalse();
    }
    
    [Fact]
    public async Task Send_UpdateRequest_Should_UpdateExistingModelIfRequestIsValid()
    {
        // Arrange
        var updatedModel = await GetUpdatedModel();
        var newEngineType = await GetNewEngineType(updatedModel);
        var newBodyType = await GetNewBodyType(updatedModel);
        var newDrivetrainType = await GetNewDrivetrainType(updatedModel);
        var newTransmissionType = await GetNewTransmissionType(updatedModel);
        
        var commandRequest = GetValidUpdateRequest(
            updatedModel, newEngineType, newBodyType, newDrivetrainType, newTransmissionType);

        // Act
        var response = await Sender.Send(commandRequest);
        var newUpdatedModel = await GetUpdatedModel();
        
        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();
        newUpdatedModel.AvailableEngineTypes
            .Should().Contain(t => t.Id.Equals(newEngineType.Id));
        newUpdatedModel.AvailableBodyTypes
            .Should().Contain(t => t.Id.Equals(newBodyType.Id));
        newUpdatedModel.AvailableDrivetrainTypes
            .Should().Contain(t => t.Id.Equals(newDrivetrainType.Id));
        newUpdatedModel.AvailableTransmissionTypes
            .Should().Contain(t => t.Id.Equals(newTransmissionType.Id));
        newUpdatedModel.MaximumProductionYear
            .Should().Be(updatedModel.MinimalProductionYear + 1);
    }
    
    [Fact]
    public async Task Send_UpdateRequest_Should_NotUpdateModelIfRequestIsInvalid()
    {
        // Arrange
        var commandRequest = new UpdateVehicleModelCommandRequest(Guid.Empty, null, [], [], [], []);

        // Act
        var response = await Sender.Send(commandRequest);
        
        // Assert
        response.Error
            .Should().NotBeNull();
        response.IsSuccess
            .Should().BeFalse();
    }

    private UpdateVehicleModelCommandRequest GetValidUpdateRequest(
        VehicleModel updatedModel,
        VehicleEngineType newEngineType,
        VehicleBodyType newBodyType,
        VehicleDrivetrainType newDrivetrainType,
        VehicleTransmissionType newTransmissionType)
    {
        return new UpdateVehicleModelCommandRequest(
            updatedModel.Id,
            updatedModel.MinimalProductionYear + 1,
            updatedModel.AvailableEngineTypes.Select(t => t.Id).Append(newEngineType.Id),
            updatedModel.AvailableTransmissionTypes.Select(t => t.Id).Append(newTransmissionType.Id),
            updatedModel.AvailableDrivetrainTypes.Select(t => t.Id).Append(newDrivetrainType.Id),
            updatedModel.AvailableBodyTypes.Select(t => t.Id).Append(newBodyType.Id)
        );
    }
    
    private async Task<VehicleTransmissionType> GetNewTransmissionType(VehicleModel updatedModel)
    {
        return await Context.Set<VehicleTransmissionType>().FirstAsync(
            t => !updatedModel.AvailableTransmissionTypes.Select(x => x.Id).Contains(t.Id));
    }

    private async Task<VehicleDrivetrainType> GetNewDrivetrainType(VehicleModel updatedModel)
    {
        return await Context.Set<VehicleDrivetrainType>().FirstAsync(
            t => !updatedModel.AvailableDrivetrainTypes.Select(x => x.Id).Contains(t.Id));
    }

    private async Task<VehicleModel> GetUpdatedModel()
    {
        return await Context.Set<VehicleModel>()
            .Include(model => model.AvailableDrivetrainTypes)
            .Include(model => model.AvailableEngineTypes)
            .Include(model => model.AvailableBodyTypes)
            .Include(model => model.AvailableTransmissionTypes)
            .FirstAsync(m => m.Name.Equals(ModelName));
    }

    private async Task<VehicleBodyType> GetNewBodyType(VehicleModel updatedModel)
    {
        return await Context.Set<VehicleBodyType>().FirstAsync(
            t => !updatedModel.AvailableBodyTypes.Select(x => x.Id).Contains(t.Id));
    }

    private async Task<VehicleEngineType> GetNewEngineType(VehicleModel updatedModel)
    {
        return await Context.Set<VehicleEngineType>().FirstAsync(
            t => !updatedModel.AvailableEngineTypes.Select(x => x.Id).Contains(t.Id));
    }

    [Fact]
    public async Task Send_CreateRequest_ShouldNot_AddModelIfBrandIdDoesNotExist()
    {
        // Arrange - use non-existing BrandId
        var type = await Context.Set<VehicleType>().FirstAsync();
        var nonExistingBrandId = Guid.NewGuid();
        var uniqueName = $"Model_{Guid.NewGuid()}";

        var attributeIds = await GetSingleVehicleAttributeIds();

        var commandRequest = new CreateVehicleModelCommandRequest(
            uniqueName,
            nonExistingBrandId,
            type.Id,
            2005,
            2010,
            attributeIds.engineTypes,
            attributeIds.transmissionTypes,
            attributeIds.drivetrainTypes,
            attributeIds.bodyTypes
        );

        // Act
        var response = await Sender.Send(commandRequest);

        // Assert - should fail validation
        AssertFailureResponse(response);

        // Verify no VehicleModel was persisted with this name
        var modelInDb = await Context.Set<VehicleModel>()
            .FirstOrDefaultAsync(m => m.Name.Equals(uniqueName));
        modelInDb.Should().BeNull();
    }

    [Fact]
    public async Task Send_CreateRequest_ShouldNot_AddModelIfTypeIdDoesNotExist()
    {
        // Arrange - use non-existing TypeId
        var brand = await Context.Set<VehicleBrand>().FirstAsync();
        var nonExistingTypeId = Guid.NewGuid();
        var uniqueName = $"Model_{Guid.NewGuid()}";

        var attributeIds = await GetSingleVehicleAttributeIds();

        var commandRequest = new CreateVehicleModelCommandRequest(
            uniqueName,
            brand.Id,
            nonExistingTypeId,
            2005,
            2010,
            attributeIds.engineTypes,
            attributeIds.transmissionTypes,
            attributeIds.drivetrainTypes,
            attributeIds.bodyTypes
        );

        // Act
        var response = await Sender.Send(commandRequest);

        // Assert - should fail validation
        AssertFailureResponse(response);

        // Verify no VehicleModel was persisted with this name
        var modelInDb = await Context.Set<VehicleModel>()
            .FirstOrDefaultAsync(m => m.Name.Equals(uniqueName));
        modelInDb.Should().BeNull();
    }

    [Fact]
    public async Task Send_CreateRequest_ShouldNot_AddModelIfNameIsDuplicate()
    {
        // Arrange - get an existing model name to create a duplicate
        var existingModelName = await Context.Set<VehicleModel>()
            .Select(m => m.Name)
            .FirstAsync();

        var brand = await Context.Set<VehicleBrand>().FirstAsync();
        var type = await Context.Set<VehicleType>().FirstAsync();

        var attributeIds = await GetSingleVehicleAttributeIds();

        var commandRequest = new CreateVehicleModelCommandRequest(
            existingModelName,
            brand.Id,
            type.Id,
            2015,
            2020,
            attributeIds.engineTypes,
            attributeIds.transmissionTypes,
            attributeIds.drivetrainTypes,
            attributeIds.bodyTypes
        );

        var countBefore = await Context.Set<VehicleModel>()
            .CountAsync(m => m.Name.Equals(existingModelName));

        // Act
        var response = await Sender.Send(commandRequest);

        // Assert - should fail due to duplicate name
        AssertFailureResponse(response);

        // Verify no additional model was created
        var countAfter = await Context.Set<VehicleModel>()
            .CountAsync(m => m.Name.Equals(existingModelName));
        countAfter.Should().Be(countBefore);
    }

    [Fact]
    public async Task Send_UpdateRequest_ShouldNot_UpdateModelIfEngineTypeIdDoesNotExist()
    {
        // Arrange - get an existing model to update
        var existingModel = await GetVehicleModelWithAllIncludes();

        var originalEngineTypeIds = existingModel.AvailableEngineTypes.Select(t => t.Id).ToList();
        var nonExistingEngineTypeId = Guid.NewGuid();

        var commandRequest = new UpdateVehicleModelCommandRequest(
            existingModel.Id,
            existingModel.MaximumProductionYear,
            originalEngineTypeIds.Append(nonExistingEngineTypeId), // Add non-existing ID
            existingModel.AvailableTransmissionTypes.Select(t => t.Id),
            existingModel.AvailableDrivetrainTypes.Select(t => t.Id),
            existingModel.AvailableBodyTypes.Select(t => t.Id)
        );

        // Act
        var response = await Sender.Send(commandRequest);

        // Assert - should fail validation
        AssertFailureResponse(response);

        // Verify model relationships were not modified
        var modelAfter = await Context.Set<VehicleModel>()
            .Include(m => m.AvailableEngineTypes)
            .AsNoTracking()
            .FirstAsync(m => m.Id.Equals(existingModel.Id));

        modelAfter.AvailableEngineTypes.Select(t => t.Id)
            .Should().BeEquivalentTo(originalEngineTypeIds);
    }

    [Fact]
    public async Task Send_UpdateRequest_Should_ReplaceRelationshipsEntirely()
    {
        // Arrange - get an existing model with relationships
        var existingModel = await GetVehicleModelWithAllIncludes();

        var originalEngineTypeIds = existingModel.AvailableEngineTypes.Select(t => t.Id).ToList();

        // Get completely different engine types (exclude the current ones)
        var newEngineTypes = await Context.Set<VehicleEngineType>()
            .Where(t => !originalEngineTypeIds.Contains(t.Id))
            .Take(2)
            .Select(t => t.Id)
            .ToListAsync();

        newEngineTypes.Should().NotBeEmpty("test database must have additional engine types");

        var commandRequest = new UpdateVehicleModelCommandRequest(
            existingModel.Id,
            existingModel.MaximumProductionYear,
            newEngineTypes, // Completely new set, excluding old ones
            existingModel.AvailableTransmissionTypes.Select(t => t.Id),
            existingModel.AvailableDrivetrainTypes.Select(t => t.Id),
            existingModel.AvailableBodyTypes.Select(t => t.Id)
        );

        // Act
        var response = await Sender.Send(commandRequest);

        // Assert - should succeed
        response.IsSuccess.Should().BeTrue();
        response.Error.Should().Be(Error.None);

        // Verify relationships were completely replaced
        var modelAfter = await Context.Set<VehicleModel>()
            .Include(m => m.AvailableEngineTypes)
            .AsNoTracking()
            .FirstAsync(m => m.Id.Equals(existingModel.Id));

        // Old engine types should be gone
        foreach (var oldEngineTypeId in originalEngineTypeIds)
        {
            modelAfter.AvailableEngineTypes
                .Should().NotContain(t => t.Id.Equals(oldEngineTypeId));
        }

        // New engine types should be present
        foreach (var newEngineTypeId in newEngineTypes)
        {
            modelAfter.AvailableEngineTypes
                .Should().Contain(t => t.Id.Equals(newEngineTypeId));
        }
    }

    private async Task<(List<Guid> engineTypes, List<Guid> transmissionTypes, List<Guid> drivetrainTypes, List<Guid> bodyTypes)>
        GetSingleVehicleAttributeIds()
    {
        var engineTypes = await Context.Set<VehicleEngineType>().Take(1).Select(x => x.Id).ToListAsync();
        var transmissionTypes = await Context.Set<VehicleTransmissionType>().Take(1).Select(x => x.Id).ToListAsync();
        var drivetrainTypes = await Context.Set<VehicleDrivetrainType>().Take(1).Select(x => x.Id).ToListAsync();
        var bodyTypes = await Context.Set<VehicleBodyType>().Take(1).Select(x => x.Id).ToListAsync();

        return (engineTypes, transmissionTypes, drivetrainTypes, bodyTypes);
    }

    private static void AssertFailureResponse(Result response)
    {
        response.IsSuccess.Should().BeFalse();
        response.Error.Should().NotBeNull();
    }

    private async Task<VehicleModel> GetVehicleModelWithAllIncludes()
    {
        return await Context.Set<VehicleModel>()
            .Include(m => m.AvailableEngineTypes)
            .Include(m => m.AvailableTransmissionTypes)
            .Include(m => m.AvailableDrivetrainTypes)
            .Include(m => m.AvailableBodyTypes)
            .FirstAsync();
    }

    private async Task<CreateVehicleModelCommandRequest> InstantiateValidCreateRequest()
    {
        var brand = await Context.Set<VehicleBrand>().FirstAsync();
        var type = await Context.Set<VehicleType>().FirstAsync();
        const int minimalProductionYear = 2005;
        const int maximumProductionYear = 2010;

        IEnumerable<VehicleEngineType> availableEngineTypes =
        [
            await Context.Set<VehicleEngineType>().OrderBy(x => x.Name).FirstAsync(),
            await Context.Set<VehicleEngineType>().OrderBy(x => x.Name).LastAsync()
        ];

        IEnumerable<VehicleTransmissionType> availableTransmissionTypes =
        [
            await Context.Set<VehicleTransmissionType>().OrderBy(x => x.Name).FirstAsync(),
            await Context.Set<VehicleTransmissionType>().OrderBy(x => x.Name).LastAsync()
        ];

        IEnumerable<VehicleDrivetrainType> availableDrivetrainTypes =
        [
            await Context.Set<VehicleDrivetrainType>().OrderBy(x => x.Name).FirstAsync(),
            await Context.Set<VehicleDrivetrainType>().OrderBy(x => x.Name).LastAsync()
        ];

        IEnumerable<VehicleBodyType> availableBodyTypes =
        [
            await Context.Set<VehicleBodyType>().OrderBy(x => x.Name).FirstAsync(),
            await Context.Set<VehicleBodyType>().OrderBy(x => x.Name).LastAsync()
        ];


        return new CreateVehicleModelCommandRequest(
            ModelName,
            brand.Id,
            type.Id,
            minimalProductionYear,
            maximumProductionYear,
            availableEngineTypes.Select(x => x.Id),
            availableTransmissionTypes.Select(x => x.Id),
            availableDrivetrainTypes.Select(x => x.Id),
            availableBodyTypes.Select(x => x.Id)
        );
    }
}