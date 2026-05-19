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
    public async Task Send_CreateRequest_ShouldNot_AddModelIfBrandIdDoesNotExist()
    {
        // Arrange
        var nonExistingBrandId = Guid.NewGuid();
        var type = await Context.Set<VehicleType>().FirstAsync();
        var uniqueName = $"TestModel_{Guid.NewGuid()}";

        var (engineTypes, transmissionTypes, drivetrainTypes, bodyTypes) = await GetVehicleTypeIdsAsync();

        var commandRequest = new CreateVehicleModelCommandRequest(
            uniqueName,
            nonExistingBrandId,
            type.Id,
            2000,
            2010,
            engineTypes,
            transmissionTypes,
            drivetrainTypes,
            bodyTypes
        );

        // Act
        var response = await Sender.Send(commandRequest);

        // Assert
        AssertFailureResponse(response);

        // Verify no model was persisted
        var persistedModel = await Context.Set<VehicleModel>()
            .FirstOrDefaultAsync(m => m.Name == uniqueName);
        persistedModel
            .Should().BeNull();
    }

    [Fact]
    public async Task Send_CreateRequest_ShouldNot_AddModelIfNameAlreadyExists()
    {
        // Arrange
        var existingModel = await Context.Set<VehicleModel>().FirstAsync();
        var brand = await Context.Set<VehicleBrand>().FirstAsync();
        var type = await Context.Set<VehicleType>().FirstAsync();

        var (engineTypes, transmissionTypes, drivetrainTypes, bodyTypes) = await GetVehicleTypeIdsAsync();

        var commandRequest = new CreateVehicleModelCommandRequest(
            existingModel.Name, // Duplicate name
            brand.Id,
            type.Id,
            2000,
            2010,
            engineTypes,
            transmissionTypes,
            drivetrainTypes,
            bodyTypes
        );

        // Act
        var response = await Sender.Send(commandRequest);

        // Assert
        AssertFailureResponse(response);
    }

    [Fact]
    public async Task Send_UpdateRequest_ShouldNot_UpdateIfEngineTypeIdDoesNotExist()
    {
        // Arrange
        var model = await LoadModelWithRelationshipsAsync();
        var originalTypeIds = ExtractRelationshipIds(model);
        var nonExistingEngineTypeId = Guid.NewGuid();

        var commandRequest = new UpdateVehicleModelCommandRequest(
            model.Id,
            model.MaximumProductionYear,
            originalTypeIds.engineTypes.Append(nonExistingEngineTypeId), // Invalid ID mixed in
            originalTypeIds.transmissionTypes,
            originalTypeIds.drivetrainTypes,
            originalTypeIds.bodyTypes
        );

        // Act
        var response = await Sender.Send(commandRequest);

        // Assert
        AssertFailureResponse(response);

        // Reload model and verify relationships are unchanged
        var reloadedModel = await LoadModelWithRelationshipsAsync(model.Id);
        AssertRelationshipsUnchanged(reloadedModel, originalTypeIds);
    }

    [Fact]
    public async Task Send_UpdateRequest_ShouldNot_UpdateIfBodyTypeIdDoesNotExist()
    {
        // Arrange
        var model = await LoadModelWithRelationshipsAsync();
        var originalTypeIds = ExtractRelationshipIds(model);
        var nonExistingBodyTypeId = Guid.NewGuid();

        var commandRequest = new UpdateVehicleModelCommandRequest(
            model.Id,
            model.MaximumProductionYear,
            originalTypeIds.engineTypes,
            originalTypeIds.transmissionTypes,
            originalTypeIds.drivetrainTypes,
            originalTypeIds.bodyTypes.Append(nonExistingBodyTypeId) // Invalid ID mixed in
        );

        // Act
        var response = await Sender.Send(commandRequest);

        // Assert
        AssertFailureResponse(response);

        // Reload model and verify relationships are unchanged
        var reloadedModel = await LoadModelWithRelationshipsAsync(model.Id);
        AssertRelationshipsUnchanged(reloadedModel, originalTypeIds);
    }

    private async Task<(List<Guid> engineTypes, List<Guid> transmissionTypes, List<Guid> drivetrainTypes, List<Guid> bodyTypes)> GetVehicleTypeIdsAsync()
    {
        var engineTypes = await Context.Set<VehicleEngineType>().Take(1).Select(x => x.Id).ToListAsync();
        var transmissionTypes = await Context.Set<VehicleTransmissionType>().Take(1).Select(x => x.Id).ToListAsync();
        var drivetrainTypes = await Context.Set<VehicleDrivetrainType>().Take(1).Select(x => x.Id).ToListAsync();
        var bodyTypes = await Context.Set<VehicleBodyType>().Take(1).Select(x => x.Id).ToListAsync();
        return (engineTypes, transmissionTypes, drivetrainTypes, bodyTypes);
    }

    private async Task<VehicleModel> LoadModelWithRelationshipsAsync(Guid? modelId = null)
    {
        var query = Context.Set<VehicleModel>()
            .Include(m => m.AvailableEngineTypes)
            .Include(m => m.AvailableTransmissionTypes)
            .Include(m => m.AvailableDrivetrainTypes)
            .Include(m => m.AvailableBodyTypes);

        return modelId.HasValue
            ? await query.FirstAsync(m => m.Id == modelId.Value)
            : await query.FirstAsync();
    }

    private (List<Guid> engineTypes, List<Guid> transmissionTypes, List<Guid> drivetrainTypes, List<Guid> bodyTypes) ExtractRelationshipIds(VehicleModel model) =>
        (
            model.AvailableEngineTypes.Select(x => x.Id).ToList(),
            model.AvailableTransmissionTypes.Select(x => x.Id).ToList(),
            model.AvailableDrivetrainTypes.Select(x => x.Id).ToList(),
            model.AvailableBodyTypes.Select(x => x.Id).ToList()
        );

    private void AssertRelationshipsUnchanged(
        VehicleModel model,
        (List<Guid> engineTypes, List<Guid> transmissionTypes, List<Guid> drivetrainTypes, List<Guid> bodyTypes) expectedTypeIds)
    {
        model.AvailableEngineTypes.Select(x => x.Id)
            .Should().BeEquivalentTo(expectedTypeIds.engineTypes);
        model.AvailableTransmissionTypes.Select(x => x.Id)
            .Should().BeEquivalentTo(expectedTypeIds.transmissionTypes);
        model.AvailableDrivetrainTypes.Select(x => x.Id)
            .Should().BeEquivalentTo(expectedTypeIds.drivetrainTypes);
        model.AvailableBodyTypes.Select(x => x.Id)
            .Should().BeEquivalentTo(expectedTypeIds.bodyTypes);
    }

    private void AssertFailureResponse<T>(Result<T> response)
    {
        response.Error.Should().NotBe(Error.None);
        response.IsSuccess.Should().BeFalse();
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