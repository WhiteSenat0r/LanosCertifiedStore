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
        var type = await Context.Set<VehicleType>().FirstAsync();
        var engineType = await Context.Set<VehicleEngineType>().FirstAsync();
        var transmissionType = await Context.Set<VehicleTransmissionType>().FirstAsync();
        var drivetrainType = await Context.Set<VehicleDrivetrainType>().FirstAsync();
        var bodyType = await Context.Set<VehicleBodyType>().FirstAsync();

        var nonExistingBrandId = Guid.NewGuid();
        var commandRequest = new CreateVehicleModelCommandRequest(
            $"Model_{Guid.NewGuid()}",
            nonExistingBrandId,
            type.Id,
            2005,
            2010,
            [engineType.Id],
            [transmissionType.Id],
            [drivetrainType.Id],
            [bodyType.Id]
        );

        var initialCount = await Context.Set<VehicleModel>().CountAsync();

        // Act
        var response = await Sender.Send(commandRequest);

        // Assert
        response.Error
            .Should().NotBe(Error.None);
        response.IsSuccess
            .Should().BeFalse();

        var finalCount = await Context.Set<VehicleModel>().CountAsync();
        finalCount.Should().Be(initialCount);
    }

    [Fact]
    public async Task Send_CreateRequest_ShouldNot_AddNewModelIfTypeIdDoesNotExist()
    {
        // Arrange
        var brand = await Context.Set<VehicleBrand>().FirstAsync();
        var engineType = await Context.Set<VehicleEngineType>().FirstAsync();
        var transmissionType = await Context.Set<VehicleTransmissionType>().FirstAsync();
        var drivetrainType = await Context.Set<VehicleDrivetrainType>().FirstAsync();
        var bodyType = await Context.Set<VehicleBodyType>().FirstAsync();

        var nonExistingTypeId = Guid.NewGuid();
        var commandRequest = new CreateVehicleModelCommandRequest(
            $"Model_{Guid.NewGuid()}",
            brand.Id,
            nonExistingTypeId,
            2005,
            2010,
            [engineType.Id],
            [transmissionType.Id],
            [drivetrainType.Id],
            [bodyType.Id]
        );

        var initialCount = await Context.Set<VehicleModel>().CountAsync();

        // Act
        var response = await Sender.Send(commandRequest);

        // Assert
        response.Error
            .Should().NotBe(Error.None);
        response.IsSuccess
            .Should().BeFalse();

        var finalCount = await Context.Set<VehicleModel>().CountAsync();
        finalCount.Should().Be(initialCount);
    }

    [Fact]
    public async Task Send_CreateRequest_ShouldNot_AddNewModelIfEngineTypeIdDoesNotExist()
    {
        // Arrange
        var brand = await Context.Set<VehicleBrand>().FirstAsync();
        var type = await Context.Set<VehicleType>().FirstAsync();
        var validEngineType = await Context.Set<VehicleEngineType>().FirstAsync();
        var transmissionType = await Context.Set<VehicleTransmissionType>().FirstAsync();
        var drivetrainType = await Context.Set<VehicleDrivetrainType>().FirstAsync();
        var bodyType = await Context.Set<VehicleBodyType>().FirstAsync();

        var nonExistingEngineTypeId = Guid.NewGuid();
        var commandRequest = new CreateVehicleModelCommandRequest(
            $"Model_{Guid.NewGuid()}",
            brand.Id,
            type.Id,
            2005,
            2010,
            [validEngineType.Id, nonExistingEngineTypeId],
            [transmissionType.Id],
            [drivetrainType.Id],
            [bodyType.Id]
        );

        var initialCount = await Context.Set<VehicleModel>().CountAsync();

        // Act
        var response = await Sender.Send(commandRequest);

        // Assert
        response.Error
            .Should().NotBe(Error.None);
        response.IsSuccess
            .Should().BeFalse();

        var finalCount = await Context.Set<VehicleModel>().CountAsync();
        finalCount.Should().Be(initialCount);
    }

    [Fact]
    public async Task Send_CreateRequest_ShouldNot_AddNewModelIfDuplicateName()
    {
        // Arrange - first create a model successfully
        var firstRequest = await InstantiateValidCreateRequest();
        var uniqueName = $"DuplicateTestModel_{Guid.NewGuid()}";
        var firstRequestWithName = firstRequest with { Name = uniqueName };

        var firstResponse = await Sender.Send(firstRequestWithName);
        firstResponse.IsSuccess.Should().BeTrue();

        var initialCount = await Context.Set<VehicleModel>().CountAsync();

        // Arrange - attempt to create second model with same name
        var secondRequest = await InstantiateValidCreateRequest();
        var secondRequestWithDuplicateName = secondRequest with { Name = uniqueName };

        // Act
        var response = await Sender.Send(secondRequestWithDuplicateName);

        // Assert
        response.Error
            .Should().NotBe(Error.None);
        response.IsSuccess
            .Should().BeFalse();

        var finalCount = await Context.Set<VehicleModel>().CountAsync();
        finalCount.Should().Be(initialCount);
    }

    [Fact]
    public async Task Send_UpdateRequest_ShouldNot_UpdateModelIfEngineTypeIdDoesNotExist()
    {
        // Arrange
        var updatedModel = await GetUpdatedModel();
        var nonExistingEngineTypeId = Guid.NewGuid();

        var originalEngineTypeIds = updatedModel.AvailableEngineTypes.Select(t => t.Id).ToList();
        var originalBodyTypeIds = updatedModel.AvailableBodyTypes.Select(t => t.Id).ToList();
        var originalDrivetrainTypeIds = updatedModel.AvailableDrivetrainTypes.Select(t => t.Id).ToList();
        var originalTransmissionTypeIds = updatedModel.AvailableTransmissionTypes.Select(t => t.Id).ToList();

        var commandRequest = new UpdateVehicleModelCommandRequest(
            updatedModel.Id,
            updatedModel.MaximumProductionYear,
            originalEngineTypeIds.Append(nonExistingEngineTypeId),
            originalTransmissionTypeIds,
            originalDrivetrainTypeIds,
            originalBodyTypeIds
        );

        // Act
        var response = await Sender.Send(commandRequest);

        // Assert
        response.Error
            .Should().NotBe(Error.None);
        response.IsSuccess
            .Should().BeFalse();

        // Verify original relationships unchanged
        var unchangedModel = await GetUpdatedModel();
        unchangedModel.AvailableEngineTypes.Select(t => t.Id)
            .Should().BeEquivalentTo(originalEngineTypeIds);
        unchangedModel.AvailableBodyTypes.Select(t => t.Id)
            .Should().BeEquivalentTo(originalBodyTypeIds);
        unchangedModel.AvailableDrivetrainTypes.Select(t => t.Id)
            .Should().BeEquivalentTo(originalDrivetrainTypeIds);
        unchangedModel.AvailableTransmissionTypes.Select(t => t.Id)
            .Should().BeEquivalentTo(originalTransmissionTypeIds);
    }

    [Fact]
    public async Task Send_UpdateRequest_Should_ReplaceEngineTypesNotAppend()
    {
        // Arrange - get model with existing engine types
        var updatedModel = await GetUpdatedModel();
        var originalEngineTypeCount = updatedModel.AvailableEngineTypes.Count;
        originalEngineTypeCount.Should().BeGreaterThan(0);

        // Get a completely different engine type not currently in the model
        var newEngineType = await Context.Set<VehicleEngineType>().FirstAsync(
            t => !updatedModel.AvailableEngineTypes.Select(x => x.Id).Contains(t.Id));

        var commandRequest = new UpdateVehicleModelCommandRequest(
            updatedModel.Id,
            updatedModel.MaximumProductionYear,
            [newEngineType.Id], // Only the new engine type, should replace all existing
            updatedModel.AvailableTransmissionTypes.Select(t => t.Id),
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

        // Verify engine types were replaced, not appended
        var newUpdatedModel = await GetUpdatedModel();
        newUpdatedModel.AvailableEngineTypes
            .Should().HaveCount(1);
        newUpdatedModel.AvailableEngineTypes.First().Id
            .Should().Be(newEngineType.Id);
        newUpdatedModel.AvailableEngineTypes.Select(t => t.Id)
            .Should().NotContain(updatedModel.AvailableEngineTypes.Select(t => t.Id));
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