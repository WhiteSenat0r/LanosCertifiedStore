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

    [Fact]
    public async Task Send_CreateRequest_ShouldNot_AddNewModelIfBrandIdDoesNotExist()
    {
        // Arrange
        const string nonExistingBrandModelName = "NonExistingBrandModel";
        var type = await Context.Set<VehicleType>().FirstAsync();
        var engineType = await Context.Set<VehicleEngineType>().FirstAsync();
        var transmissionType = await Context.Set<VehicleTransmissionType>().FirstAsync();
        var drivetrainType = await Context.Set<VehicleDrivetrainType>().FirstAsync();
        var bodyType = await Context.Set<VehicleBodyType>().FirstAsync();

        var commandRequest = new CreateVehicleModelCommandRequest(
            nonExistingBrandModelName,
            Guid.NewGuid(), // Non-existing BrandId
            type.Id,
            2005,
            2010,
            [engineType.Id],
            [transmissionType.Id],
            [drivetrainType.Id],
            [bodyType.Id]
        );

        // Act
        var response = await Sender.Send(commandRequest);
        var persistedModel = await Context.Set<VehicleModel>()
            .FirstOrDefaultAsync(m => m.Name.Equals(nonExistingBrandModelName));

        // Assert
        response.Error
            .Should().NotBe(Error.None);
        response.IsSuccess
            .Should().BeFalse();
        persistedModel
            .Should().BeNull();
    }

    [Fact]
    public async Task Send_CreateRequest_ShouldNot_AddNewModelIfTypeIdDoesNotExist()
    {
        // Arrange
        const string nonExistingTypeModelName = "NonExistingTypeModel";
        var brand = await Context.Set<VehicleBrand>().FirstAsync();
        var engineType = await Context.Set<VehicleEngineType>().FirstAsync();
        var transmissionType = await Context.Set<VehicleTransmissionType>().FirstAsync();
        var drivetrainType = await Context.Set<VehicleDrivetrainType>().FirstAsync();
        var bodyType = await Context.Set<VehicleBodyType>().FirstAsync();

        var commandRequest = new CreateVehicleModelCommandRequest(
            nonExistingTypeModelName,
            brand.Id,
            Guid.NewGuid(), // Non-existing TypeId
            2005,
            2010,
            [engineType.Id],
            [transmissionType.Id],
            [drivetrainType.Id],
            [bodyType.Id]
        );

        // Act
        var response = await Sender.Send(commandRequest);
        var persistedModel = await Context.Set<VehicleModel>()
            .FirstOrDefaultAsync(m => m.Name.Equals(nonExistingTypeModelName));

        // Assert
        response.Error
            .Should().NotBe(Error.None);
        response.IsSuccess
            .Should().BeFalse();
        persistedModel
            .Should().BeNull();
    }

    [Fact]
    public async Task Send_CreateRequest_ShouldNot_AddNewModelIfEngineTypeIdDoesNotExist()
    {
        // Arrange
        const string nonExistingEngineTypeModelName = "NonExistingEngineTypeModel";
        var brand = await Context.Set<VehicleBrand>().FirstAsync();
        var type = await Context.Set<VehicleType>().FirstAsync();
        var validEngineType = await Context.Set<VehicleEngineType>().FirstAsync();
        var transmissionType = await Context.Set<VehicleTransmissionType>().FirstAsync();
        var drivetrainType = await Context.Set<VehicleDrivetrainType>().FirstAsync();
        var bodyType = await Context.Set<VehicleBodyType>().FirstAsync();

        var commandRequest = new CreateVehicleModelCommandRequest(
            nonExistingEngineTypeModelName,
            brand.Id,
            type.Id,
            2005,
            2010,
            [validEngineType.Id, Guid.NewGuid()], // One valid, one non-existing
            [transmissionType.Id],
            [drivetrainType.Id],
            [bodyType.Id]
        );

        // Act
        var response = await Sender.Send(commandRequest);
        var persistedModel = await Context.Set<VehicleModel>()
            .FirstOrDefaultAsync(m => m.Name.Equals(nonExistingEngineTypeModelName));

        // Assert
        response.Error
            .Should().NotBe(Error.None);
        response.IsSuccess
            .Should().BeFalse();
        persistedModel
            .Should().BeNull();
    }

    [Fact]
    public async Task Send_CreateRequest_ShouldNot_AddNewModelIfNameAlreadyExists()
    {
        // Arrange
        var existingModel = await Context.Set<VehicleModel>().FirstAsync();
        var brand = await Context.Set<VehicleBrand>().FirstAsync();
        var type = await Context.Set<VehicleType>().FirstAsync();
        var engineType = await Context.Set<VehicleEngineType>().FirstAsync();
        var transmissionType = await Context.Set<VehicleTransmissionType>().FirstAsync();
        var drivetrainType = await Context.Set<VehicleDrivetrainType>().FirstAsync();
        var bodyType = await Context.Set<VehicleBodyType>().FirstAsync();

        var commandRequest = new CreateVehicleModelCommandRequest(
            existingModel.Name, // Duplicate name
            brand.Id,
            type.Id,
            2005,
            2010,
            [engineType.Id],
            [transmissionType.Id],
            [drivetrainType.Id],
            [bodyType.Id]
        );

        // Act
        var response = await Sender.Send(commandRequest);
        var modelCount = await Context.Set<VehicleModel>()
            .CountAsync(m => m.Name.Equals(existingModel.Name));

        // Assert
        response.Error
            .Should().NotBe(Error.None);
        response.IsSuccess
            .Should().BeFalse();
        modelCount
            .Should().Be(1); // Only the original model, no duplicate created
    }

    [Fact]
    public async Task Send_UpdateRequest_ShouldNot_UpdateModelIfBodyTypeIdDoesNotExist()
    {
        // Arrange
        var existingModel = await GetUpdatedModel();
        var originalBodyTypeIds = existingModel.AvailableBodyTypes.Select(bt => bt.Id).ToList();
        var originalProductionYear = existingModel.MaximumProductionYear;
        var originalEngineTypeCount = existingModel.AvailableEngineTypes.Count;

        var commandRequest = new UpdateVehicleModelCommandRequest(
            existingModel.Id,
            2025, // New production year
            existingModel.AvailableEngineTypes.Select(t => t.Id),
            existingModel.AvailableTransmissionTypes.Select(t => t.Id),
            existingModel.AvailableDrivetrainTypes.Select(t => t.Id),
            originalBodyTypeIds.Append(Guid.NewGuid()) // Add non-existing BodyTypeId
        );

        // Act
        var response = await Sender.Send(commandRequest);
        var modelAfterFailedUpdate = await GetUpdatedModel();

        // Assert
        response.Error
            .Should().NotBe(Error.None);
        response.IsSuccess
            .Should().BeFalse();
        modelAfterFailedUpdate.MaximumProductionYear
            .Should().Be(originalProductionYear); // No change
        modelAfterFailedUpdate.AvailableBodyTypes.Select(bt => bt.Id)
            .Should().BeEquivalentTo(originalBodyTypeIds); // No change
        modelAfterFailedUpdate.AvailableEngineTypes.Count
            .Should().Be(originalEngineTypeCount); // No change
    }

    [Fact]
    public async Task Send_UpdateRequest_Should_ReplaceEngineTypeCollectionNotAppend()
    {
        // Arrange
        var existingModel = await GetUpdatedModel();
        var originalEngineTypeIds = existingModel.AvailableEngineTypes.Select(et => et.Id).ToList();

        // Get completely different engine types (not in current model)
        var newEngineTypes = await Context.Set<VehicleEngineType>()
            .Where(et => !originalEngineTypeIds.Contains(et.Id))
            .Take(2)
            .ToListAsync();

        var commandRequest = new UpdateVehicleModelCommandRequest(
            existingModel.Id,
            existingModel.MaximumProductionYear,
            newEngineTypes.Select(t => t.Id), // Completely new engine types
            existingModel.AvailableTransmissionTypes.Select(t => t.Id),
            existingModel.AvailableDrivetrainTypes.Select(t => t.Id),
            existingModel.AvailableBodyTypes.Select(t => t.Id)
        );

        // Act
        var response = await Sender.Send(commandRequest);
        var updatedModel = await GetUpdatedModel();

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();
        updatedModel.AvailableEngineTypes.Select(et => et.Id)
            .Should().BeEquivalentTo(newEngineTypes.Select(et => et.Id)); // Only new types
        updatedModel.AvailableEngineTypes.Select(et => et.Id)
            .Should().NotContain(originalEngineTypeIds); // Old types removed
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