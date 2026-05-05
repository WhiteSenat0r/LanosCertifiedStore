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
    public async Task Send_CreateRequest_ShouldNot_AddModelWithNonExistingBrandId()
    {
        // Arrange
        var (_, type, engineType, transmissionType, drivetrainType, bodyType) = await GetAllVehicleTypes();

        var commandRequest = new CreateVehicleModelCommandRequest(
            "NonExistingBrandModel",
            Guid.NewGuid(),
            type.Id,
            2010,
            2020,
            [engineType.Id],
            [transmissionType.Id],
            [drivetrainType.Id],
            [bodyType.Id]
        );

        // Act & Assert
        await AssertCommandFailure(commandRequest);
    }

    [Fact]
    public async Task Send_CreateRequest_ShouldNot_AddModelWithNonExistingVehicleTypeId()
    {
        // Arrange
        var (brand, _, engineType, transmissionType, drivetrainType, bodyType) = await GetAllVehicleTypes();

        var commandRequest = new CreateVehicleModelCommandRequest(
            "NonExistingTypeModel",
            brand.Id,
            Guid.NewGuid(),
            2010,
            2020,
            [engineType.Id],
            [transmissionType.Id],
            [drivetrainType.Id],
            [bodyType.Id]
        );

        // Act & Assert
        await AssertCommandFailure(commandRequest);
    }

    [Fact]
    public async Task Send_CreateRequest_ShouldNot_AddModelWithNonExistingEngineTypeId()
    {
        // Arrange
        var (brand, type, _, transmissionType, drivetrainType, bodyType) = await GetAllVehicleTypes();

        var commandRequest = new CreateVehicleModelCommandRequest(
            "NonExistingEngineTypeModel",
            brand.Id,
            type.Id,
            2010,
            2020,
            [Guid.NewGuid()],
            [transmissionType.Id],
            [drivetrainType.Id],
            [bodyType.Id]
        );

        // Act & Assert
        await AssertCommandFailure(commandRequest);
    }

    [Fact]
    public async Task Send_CreateRequest_ShouldNot_AddModelWithNonExistingTransmissionTypeId()
    {
        // Arrange
        var (brand, type, engineType, _, drivetrainType, bodyType) = await GetAllVehicleTypes();

        var commandRequest = new CreateVehicleModelCommandRequest(
            "NonExistingTransmissionTypeModel",
            brand.Id,
            type.Id,
            2010,
            2020,
            [engineType.Id],
            [Guid.NewGuid()],
            [drivetrainType.Id],
            [bodyType.Id]
        );

        // Act & Assert
        await AssertCommandFailure(commandRequest);
    }

    [Fact]
    public async Task Send_CreateRequest_ShouldNot_AddModelWithNonExistingDrivetrainTypeId()
    {
        // Arrange
        var (brand, type, engineType, transmissionType, _, bodyType) = await GetAllVehicleTypes();

        var commandRequest = new CreateVehicleModelCommandRequest(
            "NonExistingDrivetrainTypeModel",
            brand.Id,
            type.Id,
            2010,
            2020,
            [engineType.Id],
            [transmissionType.Id],
            [Guid.NewGuid()],
            [bodyType.Id]
        );

        // Act & Assert
        await AssertCommandFailure(commandRequest);
    }

    [Fact]
    public async Task Send_CreateRequest_ShouldNot_AddModelWithNonExistingBodyTypeId()
    {
        // Arrange
        var (brand, type, engineType, transmissionType, drivetrainType, _) = await GetAllVehicleTypes();

        var commandRequest = new CreateVehicleModelCommandRequest(
            "NonExistingBodyTypeModel",
            brand.Id,
            type.Id,
            2010,
            2020,
            [engineType.Id],
            [transmissionType.Id],
            [drivetrainType.Id],
            [Guid.NewGuid()]
        );

        // Act & Assert
        await AssertCommandFailure(commandRequest);
    }

    [Fact]
    public async Task Send_CreateRequest_ShouldNot_AddModelWithInvalidProductionYearRange()
    {
        // Arrange
        var (brand, type, engineType, transmissionType, drivetrainType, bodyType) = await GetAllVehicleTypes();

        var commandRequest = new CreateVehicleModelCommandRequest(
            "InvalidYearRangeModel",
            brand.Id,
            type.Id,
            2020,
            2010,
            [engineType.Id],
            [transmissionType.Id],
            [drivetrainType.Id],
            [bodyType.Id]
        );

        // Act & Assert
        await AssertCommandFailure(commandRequest);
    }

    [Fact]
    public async Task Send_UpdateRequest_ShouldNot_UpdateModelWithNonExistingId()
    {
        // Arrange
        var (engineType, transmissionType, drivetrainType, bodyType) = await GetVehicleTypesForUpdate();

        var commandRequest = new UpdateVehicleModelCommandRequest(
            Guid.NewGuid(),
            2025,
            [engineType.Id],
            [transmissionType.Id],
            [drivetrainType.Id],
            [bodyType.Id]
        );

        // Act & Assert
        await AssertCommandFailure(commandRequest);
    }

    [Fact]
    public async Task Send_UpdateRequest_ShouldNot_UpdateModelWithNonExistingEngineTypeId()
    {
        // Arrange
        var model = await GetUpdatedModel();
        var (_, transmissionType, drivetrainType, bodyType) = await GetVehicleTypesForUpdate();

        var commandRequest = new UpdateVehicleModelCommandRequest(
            model.Id,
            model.MaximumProductionYear,
            [Guid.NewGuid()],
            [transmissionType.Id],
            [drivetrainType.Id],
            [bodyType.Id]
        );

        // Act & Assert
        await AssertCommandFailure(commandRequest);
    }

    [Fact]
    public async Task Send_UpdateRequest_ShouldNot_UpdateModelWithInvalidProductionYearRange()
    {
        // Arrange
        var model = await GetUpdatedModel();
        var (engineType, transmissionType, drivetrainType, bodyType) = await GetVehicleTypesForUpdate();

        var commandRequest = new UpdateVehicleModelCommandRequest(
            model.Id,
            model.MinimalProductionYear - 10,
            [engineType.Id],
            [transmissionType.Id],
            [drivetrainType.Id],
            [bodyType.Id]
        );

        // Act & Assert
        await AssertCommandFailure(commandRequest);
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

    private async Task<(VehicleBrand brand, VehicleType type, VehicleEngineType engineType,
        VehicleTransmissionType transmissionType, VehicleDrivetrainType drivetrainType,
        VehicleBodyType bodyType)> GetAllVehicleTypes()
    {
        return (
            await Context.Set<VehicleBrand>().FirstAsync(),
            await Context.Set<VehicleType>().FirstAsync(),
            await Context.Set<VehicleEngineType>().FirstAsync(),
            await Context.Set<VehicleTransmissionType>().FirstAsync(),
            await Context.Set<VehicleDrivetrainType>().FirstAsync(),
            await Context.Set<VehicleBodyType>().FirstAsync()
        );
    }

    private async Task<(VehicleEngineType engineType, VehicleTransmissionType transmissionType,
        VehicleDrivetrainType drivetrainType, VehicleBodyType bodyType)> GetVehicleTypesForUpdate()
    {
        return (
            await Context.Set<VehicleEngineType>().FirstAsync(),
            await Context.Set<VehicleTransmissionType>().FirstAsync(),
            await Context.Set<VehicleDrivetrainType>().FirstAsync(),
            await Context.Set<VehicleBodyType>().FirstAsync()
        );
    }

    private async Task AssertCommandFailure<T>(T commandRequest) where T : notnull
    {
        var response = await Sender.Send(commandRequest);

        response.Error
            .Should().NotBeNull();
        response.IsSuccess
            .Should().BeFalse();
    }
}