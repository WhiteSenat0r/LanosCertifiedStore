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
    public async Task Send_CreateRequest_WithNonExistingBrandId_Should_FailAndNotPersist()
    {
        // Arrange
        var uniqueName = $"TestModel_{Guid.NewGuid()}";
        var nonExistingBrandId = Guid.NewGuid();
        var type = await Context.Set<VehicleType>().FirstAsync();

        var typeIds = await GetTypeIds();

        var commandRequest = new CreateVehicleModelCommandRequest(
            uniqueName,
            nonExistingBrandId,
            type.Id,
            2005,
            2010,
            [typeIds.EngineTypeId],
            [typeIds.TransmissionTypeId],
            [typeIds.DrivetrainTypeId],
            [typeIds.BodyTypeId]
        );

        // Act
        var response = await Sender.Send(commandRequest);

        // Assert
        response.Error
            .Should().NotBeNull();
        response.IsSuccess
            .Should().BeFalse();

        // Verify no model was persisted with this name
        var createdModel = await Context.Set<VehicleModel>()
            .FirstOrDefaultAsync(m => m.Name == uniqueName);
        createdModel
            .Should().BeNull();
    }

    [Fact]
    public async Task Send_CreateRequest_WithDuplicateName_Should_Fail()
    {
        // Arrange - fetch an existing model name
        var existingModel = await Context.Set<VehicleModel>().FirstAsync();
        var brand = await Context.Set<VehicleBrand>().FirstAsync();
        var type = await Context.Set<VehicleType>().FirstAsync();
        var initialCount = await Context.Set<VehicleModel>()
            .CountAsync(m => m.Name == existingModel.Name);

        var typeIds = await GetTypeIds();

        var commandRequest = new CreateVehicleModelCommandRequest(
            existingModel.Name, // duplicate name
            brand.Id,
            type.Id,
            2005,
            2010,
            [typeIds.EngineTypeId],
            [typeIds.TransmissionTypeId],
            [typeIds.DrivetrainTypeId],
            [typeIds.BodyTypeId]
        );

        // Act
        var response = await Sender.Send(commandRequest);

        // Assert
        response.Error
            .Should().NotBeNull();
        response.IsSuccess
            .Should().BeFalse();

        // Verify no duplicate was created
        var finalCount = await Context.Set<VehicleModel>()
            .CountAsync(m => m.Name == existingModel.Name);
        finalCount
            .Should().Be(initialCount);
    }

    [Fact]
    public async Task Send_UpdateRequest_WithNonExistingEngineTypeId_Should_FailAndNotModify()
    {
        // Arrange
        var updatedModel = await GetUpdatedModel();
        var originalEngineTypeIds = updatedModel.AvailableEngineTypes.Select(t => t.Id).ToList();
        var nonExistingEngineTypeId = Guid.NewGuid();

        var commandRequest = new UpdateVehicleModelCommandRequest(
            updatedModel.Id,
            updatedModel.MaximumProductionYear,
            originalEngineTypeIds.Append(nonExistingEngineTypeId),
            updatedModel.AvailableTransmissionTypes.Select(t => t.Id),
            updatedModel.AvailableDrivetrainTypes.Select(t => t.Id),
            updatedModel.AvailableBodyTypes.Select(t => t.Id)
        );

        // Act
        var response = await Sender.Send(commandRequest);

        // Assert
        response.Error
            .Should().NotBeNull();
        response.IsSuccess
            .Should().BeFalse();

        // Verify relationships unchanged - refetch with includes
        var verifyModel = await Context.Set<VehicleModel>()
            .Include(m => m.AvailableEngineTypes)
            .FirstAsync(m => m.Id == updatedModel.Id);

        verifyModel.AvailableEngineTypes.Select(t => t.Id)
            .Should().BeEquivalentTo(originalEngineTypeIds);
        verifyModel.AvailableEngineTypes
            .Should().NotContain(t => t.Id == nonExistingEngineTypeId);
    }

    [Fact]
    public async Task Send_UpdateRequest_Should_CompletelyReplaceTypeCollections()
    {
        // Arrange
        var updatedModel = await GetUpdatedModel();

        // Get completely different sets of types (not overlapping with current)
        var existingEngineTypeIds = updatedModel.AvailableEngineTypes.Select(x => x.Id).ToHashSet();
        var newEngineTypes = await Context.Set<VehicleEngineType>()
            .Where(t => !existingEngineTypeIds.Contains(t.Id))
            .OrderBy(t => t.Id)
            .Take(2)
            .Select(t => t.Id)
            .ToListAsync();

        var existingTransmissionTypeIds = updatedModel.AvailableTransmissionTypes.Select(x => x.Id).ToHashSet();
        var newTransmissionTypes = await Context.Set<VehicleTransmissionType>()
            .Where(t => !existingTransmissionTypeIds.Contains(t.Id))
            .OrderBy(t => t.Id)
            .Take(2)
            .Select(t => t.Id)
            .ToListAsync();

        var oldEngineTypeIds = existingEngineTypeIds.ToList();
        var oldTransmissionTypeIds = existingTransmissionTypeIds.ToList();

        var commandRequest = new UpdateVehicleModelCommandRequest(
            updatedModel.Id,
            updatedModel.MaximumProductionYear,
            newEngineTypes,
            newTransmissionTypes,
            updatedModel.AvailableDrivetrainTypes.Select(t => t.Id),
            updatedModel.AvailableBodyTypes.Select(t => t.Id)
        );

        // Act
        var response = await Sender.Send(commandRequest);

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();

        // Verify complete replacement - old types removed, only new types present
        var verifyModel = await Context.Set<VehicleModel>()
            .Include(m => m.AvailableEngineTypes)
            .Include(m => m.AvailableTransmissionTypes)
            .FirstAsync(m => m.Id == updatedModel.Id);

        // New types should be present
        verifyModel.AvailableEngineTypes.Select(t => t.Id)
            .Should().BeEquivalentTo(newEngineTypes);
        verifyModel.AvailableTransmissionTypes.Select(t => t.Id)
            .Should().BeEquivalentTo(newTransmissionTypes);

        // Old types should be completely removed
        verifyModel.AvailableEngineTypes
            .Should().NotContain(t => oldEngineTypeIds.Contains(t.Id));
        verifyModel.AvailableTransmissionTypes
            .Should().NotContain(t => oldTransmissionTypeIds.Contains(t.Id));
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

    private async Task<(Guid EngineTypeId, Guid TransmissionTypeId, Guid DrivetrainTypeId, Guid BodyTypeId)> GetTypeIds()
    {
        var engineTypeId = await Context.Set<VehicleEngineType>().Select(t => t.Id).FirstAsync();
        var transmissionTypeId = await Context.Set<VehicleTransmissionType>().Select(t => t.Id).FirstAsync();
        var drivetrainTypeId = await Context.Set<VehicleDrivetrainType>().Select(t => t.Id).FirstAsync();
        var bodyTypeId = await Context.Set<VehicleBodyType>().Select(t => t.Id).FirstAsync();

        return (engineTypeId, transmissionTypeId, drivetrainTypeId, bodyTypeId);
    }
}