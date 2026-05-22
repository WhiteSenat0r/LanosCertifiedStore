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
    public async Task Send_CreateRequest_ShouldNot_AddNewModel_IfBrandIdDoesNotExist()
    {
        // Arrange
        const string testModelName = "test-nonexisting-brand";
        var nonExistingBrandId = Guid.NewGuid();
        var type = await Context.Set<VehicleType>().FirstAsync();

        var availableEngineTypes = new[]
        {
            await Context.Set<VehicleEngineType>().OrderBy(x => x.Name).FirstAsync()
        };
        var availableTransmissionTypes = new[]
        {
            await Context.Set<VehicleTransmissionType>().OrderBy(x => x.Name).FirstAsync()
        };
        var availableDrivetrainTypes = new[]
        {
            await Context.Set<VehicleDrivetrainType>().OrderBy(x => x.Name).FirstAsync()
        };
        var availableBodyTypes = new[]
        {
            await Context.Set<VehicleBodyType>().OrderBy(x => x.Name).FirstAsync()
        };

        var commandRequest = new CreateVehicleModelCommandRequest(
            testModelName,
            nonExistingBrandId,
            type.Id,
            2005,
            2010,
            availableEngineTypes.Select(x => x.Id),
            availableTransmissionTypes.Select(x => x.Id),
            availableDrivetrainTypes.Select(x => x.Id),
            availableBodyTypes.Select(x => x.Id)
        );

        // Act
        var response = await Sender.Send(commandRequest);
        var createdModel = await Context.Set<VehicleModel>()
            .FirstOrDefaultAsync(m => m.Name.Equals(testModelName));

        // Assert
        response.Error
            .Should().NotBe(Error.None);
        response.IsSuccess
            .Should().BeFalse();
        createdModel
            .Should().BeNull();
    }

    [Fact]
    public async Task Send_CreateRequest_ShouldNot_AddNewModel_IfEngineTypeIdDoesNotExist()
    {
        // Arrange
        const string testModelName = "test-nonexisting-enginetype";
        var brand = await Context.Set<VehicleBrand>().FirstAsync();
        var type = await Context.Set<VehicleType>().FirstAsync();
        var nonExistingEngineTypeId = Guid.NewGuid();

        var availableTransmissionTypes = new[]
        {
            await Context.Set<VehicleTransmissionType>().OrderBy(x => x.Name).FirstAsync()
        };
        var availableDrivetrainTypes = new[]
        {
            await Context.Set<VehicleDrivetrainType>().OrderBy(x => x.Name).FirstAsync()
        };
        var availableBodyTypes = new[]
        {
            await Context.Set<VehicleBodyType>().OrderBy(x => x.Name).FirstAsync()
        };

        var commandRequest = new CreateVehicleModelCommandRequest(
            testModelName,
            brand.Id,
            type.Id,
            2005,
            2010,
            new[] { nonExistingEngineTypeId },
            availableTransmissionTypes.Select(x => x.Id),
            availableDrivetrainTypes.Select(x => x.Id),
            availableBodyTypes.Select(x => x.Id)
        );

        // Act
        var response = await Sender.Send(commandRequest);
        var createdModel = await Context.Set<VehicleModel>()
            .FirstOrDefaultAsync(m => m.Name.Equals(testModelName));

        // Assert
        response.Error
            .Should().NotBe(Error.None);
        response.IsSuccess
            .Should().BeFalse();
        createdModel
            .Should().BeNull();
    }

    [Fact]
    public async Task Send_CreateRequest_ShouldNot_AddNewModel_IfNameAlreadyExists()
    {
        // Arrange
        const string duplicateModelName = "test-duplicate-name";

        // First, create a valid model
        var firstCommandRequest = await InstantiateValidCreateRequestWithCustomName(duplicateModelName);
        var firstResponse = await Sender.Send(firstCommandRequest);
        firstResponse.IsSuccess.Should().BeTrue();

        // Now try to create another model with the same name
        var secondCommandRequest = await InstantiateValidCreateRequestWithCustomName(duplicateModelName);

        // Act
        var response = await Sender.Send(secondCommandRequest);
        var modelsWithSameName = await Context.Set<VehicleModel>()
            .Where(m => m.Name.Equals(duplicateModelName))
            .ToListAsync();

        // Assert
        response.Error
            .Should().NotBe(Error.None);
        response.IsSuccess
            .Should().BeFalse();
        modelsWithSameName
            .Should().HaveCount(1);
    }

    [Fact]
    public async Task Send_UpdateRequest_ShouldNot_UpdateModel_IfEngineTypeIdDoesNotExist()
    {
        // Arrange
        var updatedModel = await GetUpdatedModel();
        var nonExistingEngineTypeId = Guid.NewGuid();

        // Store original engine types for comparison
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

        // Reload model to verify relationships unchanged
        var reloadedModel = await GetUpdatedModel();

        // Assert
        response.Error
            .Should().NotBe(Error.None);
        response.IsSuccess
            .Should().BeFalse();
        reloadedModel.AvailableEngineTypes
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
        return await InstantiateValidCreateRequestWithCustomName(ModelName);
    }

    private async Task<CreateVehicleModelCommandRequest> InstantiateValidCreateRequestWithCustomName(string modelName)
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
            modelName,
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