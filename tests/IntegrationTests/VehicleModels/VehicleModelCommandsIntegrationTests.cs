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

    // Error message fragments for assertions
    private const string BrandNotFoundErrorFragment = "Brand with such ID does not exist";
    private const string TypeNotFoundErrorFragment = "Type with such ID does not exist";
    private const string ModelAlreadyExistsErrorFragment = "already exists";
    private const string EngineTypeNotFoundErrorFragment = "Engine type with ID";
    
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
    public async Task Send_CreateRequest_ShouldNot_PersistModelWhenBrandIdDoesNotExist()
    {
        // Arrange
        var nonExistingBrandId = Guid.NewGuid();
        var type = await Context.Set<VehicleType>().FirstAsync();
        var (engineType, transmissionType, drivetrainType, bodyType) = await GetFirstAvailableVehicleTypes();

        var commandRequest = new CreateVehicleModelCommandRequest(
            "NonExistingBrandModel",
            nonExistingBrandId,
            type.Id,
            2020,
            2024,
            [engineType.Id],
            [transmissionType.Id],
            [drivetrainType.Id],
            [bodyType.Id]
        );

        // Act
        var response = await Sender.Send(commandRequest);
        var modelInDatabase = await Context.Set<VehicleModel>()
            .FirstOrDefaultAsync(m => m.Name.Equals("NonExistingBrandModel"));

        // Assert
        AssertCommandFailed(response, BrandNotFoundErrorFragment);
        modelInDatabase
            .Should().BeNull();
    }

    [Fact]
    public async Task Send_CreateRequest_ShouldNot_PersistModelWhenTypeIdDoesNotExist()
    {
        // Arrange
        var brand = await Context.Set<VehicleBrand>().FirstAsync();
        var nonExistingTypeId = Guid.NewGuid();
        var (engineType, transmissionType, drivetrainType, bodyType) = await GetFirstAvailableVehicleTypes();

        var commandRequest = new CreateVehicleModelCommandRequest(
            "NonExistingTypeModel",
            brand.Id,
            nonExistingTypeId,
            2020,
            2024,
            [engineType.Id],
            [transmissionType.Id],
            [drivetrainType.Id],
            [bodyType.Id]
        );

        // Act
        var response = await Sender.Send(commandRequest);
        var modelInDatabase = await Context.Set<VehicleModel>()
            .FirstOrDefaultAsync(m => m.Name.Equals("NonExistingTypeModel"));

        // Assert
        AssertCommandFailed(response, TypeNotFoundErrorFragment);
        modelInDatabase
            .Should().BeNull();
    }

    [Fact]
    public async Task Send_CreateRequest_ShouldNot_PersistModelWhenNameAlreadyExists()
    {
        // Arrange
        var commandRequest = await InstantiateValidCreateRequest();
        var initialModelCount = await Context.Set<VehicleModel>()
            .CountAsync(m => m.Name.Equals(ModelName));

        // Act
        var response = await Sender.Send(commandRequest);
        var finalModelCount = await Context.Set<VehicleModel>()
            .CountAsync(m => m.Name.Equals(ModelName));

        // Assert
        AssertCommandFailed(response, ModelAlreadyExistsErrorFragment);
        finalModelCount
            .Should().Be(initialModelCount);
    }

    [Fact]
    public async Task Send_UpdateRequest_ShouldNot_UpdateModelWhenEngineTypeIdDoesNotExist()
    {
        // Arrange
        var updatedModel = await GetUpdatedModel();
        var nonExistingEngineTypeId = Guid.NewGuid();

        var originalEngineTypeIds = updatedModel.AvailableEngineTypes.Select(t => t.Id).ToList();

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

        // Detach the entity to ensure fresh data from database
        Context.Entry(updatedModel).State = EntityState.Detached;
        var modelAfterFailedUpdate = await GetUpdatedModel();

        // Assert
        AssertCommandFailed(response, EngineTypeNotFoundErrorFragment);
        modelAfterFailedUpdate.AvailableEngineTypes
            .Select(t => t.Id)
            .Should().BeEquivalentTo(originalEngineTypeIds);
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

    private async Task<(VehicleEngineType EngineType, VehicleTransmissionType TransmissionType, VehicleDrivetrainType DrivetrainType, VehicleBodyType BodyType)> GetFirstAvailableVehicleTypes()
    {
        var engineType = await Context.Set<VehicleEngineType>().FirstAsync();
        var transmissionType = await Context.Set<VehicleTransmissionType>().FirstAsync();
        var drivetrainType = await Context.Set<VehicleDrivetrainType>().FirstAsync();
        var bodyType = await Context.Set<VehicleBodyType>().FirstAsync();

        return (engineType, transmissionType, drivetrainType, bodyType);
    }

    private static void AssertCommandFailed(Result response, string expectedErrorFragment)
    {
        response.Error
            .Should().NotBeNull();
        response.IsSuccess
            .Should().BeFalse();
        response.Error.Message
            .Should().Contain(expectedErrorFragment);
    }
}