using System.Text;
using IntegrationTests.Common;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.Vehicles.Commands.CreateVehicleCommandRequestRelated;
using LanosCertifiedStore.Application.Vehicles.Commands.DeleteVehicleCommandRequestRelated;
using LanosCertifiedStore.Application.Vehicles.Commands.UpdateVehicleCommandRequestRelated;
using LanosCertifiedStore.Domain.Entities.UserRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.LocationRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTests.Vehicle;

public sealed class VehicleCommandsIntegrationTests(
    IntegrationTestsWebApplicationFactory factory) : IntegrationTestBase(factory)
{
    [Fact]
    public async Task Send_CreateRequest_Should_AddNewVehicleIfRequestIsValid()
    {
        // Arrange
        await RegisterUserOnKeycloakAndAddToDb(
            Faker.Internet.Email(),
            Faker.Internet.Password(),
            Faker.Phone.UkrainianPhoneNumber(),
            UserRole.User);

        var commandRequest = await InstantiateValidCreateRequest();
        
        // Act
        var response = await Sender.Send(commandRequest);
        var createdVehicle = await Context.FindAsync<LanosCertifiedStore.Domain.Entities.VehicleRelated.Vehicle>(response.Value);
        
        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();
        response.Value
            .Should().NotBeEmpty();
        
        createdVehicle
            .Should().NotBeNull();
        createdVehicle!.Vincode
            .Should().Be(commandRequest.Vincode);
    }
    
    [Fact]
    public async Task Send_CreateRequest_ShouldNot_AddNewModelIfRequestIsInvalid()
    {
        // Arrange
        var commandRequest = InstantiateInvalidCreateRequest();
        
        // Act
        var response = await Sender.Send(commandRequest);
        
        // Assert
        response.Error
            .Should().NotBeNull();
        response.IsSuccess
            .Should().BeFalse();
    }
    
    [Fact]
    public async Task Send_UpdateRequest_Should_UpdateExistingVehicleIfRequestIsValid()
    {
        // Arrange
        await RegisterUserOnKeycloakAndAddToDb(
            Faker.Internet.Email(),
            Faker.Internet.Password(),
            Faker.Phone.UkrainianPhoneNumber(),
            UserRole.User);
        
        var createCommandRequest = await InstantiateValidCreateRequest();
        var result = await Sender.Send(createCommandRequest);
        var updateCommandRequest = await InstantiateValidUpdateRequest(result.Value);
        
        // Act
        var response = await Sender.Send(updateCommandRequest);
        
        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();
    }
    
    [Fact]
    public async Task Send_UpdateRequest_ShouldNot_UpdateExistingModelIfRequestIsInvalid()
    {
        // Arrange
        var commandRequest = InstantiateInvalidUpdateRequest();
        
        // Act
        var response = await Sender.Send(commandRequest);
        
        // Assert
        response.Error
            .Should().NotBeNull();
        response.IsSuccess
            .Should().BeFalse();
    }
    
    [Fact]
    public async Task Send_DeleteRequest_Should_RemoveVehicleIfExists()
    {
        // Arrange
        await RegisterUserOnKeycloakAndAddToDb(
            Faker.Internet.Email(),
            Faker.Internet.Password(),
            Faker.Phone.UkrainianPhoneNumber(),
            UserRole.User);

        var createCommandRequest = await InstantiateValidCreateRequest();
        var result = await Sender.Send(createCommandRequest);
        var vehicleId = result.Value;

        // Act
        var response = await Sender.Send(new DeleteVehicleCommandRequest(vehicleId));

        // Assert
        response.Error
            .Should().Be(Error.None);
        response.IsSuccess
            .Should().BeTrue();
    }

    [Fact]
    public async Task Send_DeleteRequest_Should_ReturnNotFoundErrorIfVehicleDoesNotExist()
    {
        // Arrange
        var nonExistentVehicleId = Guid.NewGuid();

        // Act
        var response = await Sender.Send(new DeleteVehicleCommandRequest(nonExistentVehicleId));

        // Assert
        response.Error
            .Should().Be(Error.NotFound(nonExistentVehicleId));
        response.IsSuccess
            .Should().BeFalse();
    }

    private async Task<CreateVehicleCommandRequest> InstantiateValidCreateRequest()
    {
        var brand = await Context.Set<VehicleBrand>()
            .FirstAsync(b => b.Name.Equals("Volkswagen"));
        var model = await Context.Set<VehicleModel>().FirstAsync(model => model.VehicleBrandId.Equals(brand.Id));
        var bodyType = await Context.Set<VehicleBodyType>().FirstAsync(body => body.Models.Any(m => m.Id.Equals(model.Id)));
        var engineType = await Context.Set<VehicleEngineType>().FirstAsync(engine => engine.Models.Any(m => m.Id.Equals(model.Id)));
        var transmissionType = await Context.Set<VehicleTransmissionType>().FirstAsync(transmission => transmission.Models.Any(m => m.Id.Equals(model.Id)));
        var drivetrainType = await Context.Set<VehicleDrivetrainType>().FirstAsync(drivetrain => drivetrain.Models.Any(m => m.Id.Equals(model.Id)));
        var color = await Context.Set<VehicleColor>().FirstAsync();
        var location = await Context.Set<VehicleLocationTown>().FirstAsync();

        return new CreateVehicleCommandRequest(
            brand.Id,
            model.Id,
            model.VehicleTypeId,
            bodyType.Id,
            engineType.Id,
            transmissionType.Id,
            drivetrainType.Id,
            color.Id,
            location.Id,
            "Test description for test vehicle",
            3.5,
            12345.67m,
            2024,
            1000,
            GenerateRandomVin()
        );
    }
    
    private CreateVehicleCommandRequest InstantiateInvalidCreateRequest()
    {
        return new CreateVehicleCommandRequest(
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default
        );
    }
    
    private async Task<UpdateVehicleCommandRequest> InstantiateValidUpdateRequest(Guid vehicleId)
    {
        var updatedVehicle = await Context.Set<LanosCertifiedStore.Domain.Entities.VehicleRelated.Vehicle>().SingleAsync(v => v.Id.Equals(vehicleId));
        
        return new UpdateVehicleCommandRequest(
            updatedVehicle.Id,
            updatedVehicle.ColorId,
            updatedVehicle.BodyTypeId,
            updatedVehicle.EngineTypeId,
            updatedVehicle.TransmissionTypeId,
            updatedVehicle.DrivetrainTypeId,
            updatedVehicle.LocationTownId,
            "Test description for test vehicle1",
            3.7,
            12345.68m,
            2023,
            1001
        );
    }
    
    private UpdateVehicleCommandRequest InstantiateInvalidUpdateRequest()
    {
        return new UpdateVehicleCommandRequest(
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default
        );
    }
    
    private string GenerateRandomVin()
    {
        const string allowedChars = "ABCDEFGHJKLMNPRSTUVWXYZ0123456789";
        
        var random = new Random();
        var sb = new StringBuilder(17);

        for (var i = 0; i < 17; i++)
        {
            sb.Append(allowedChars[random.Next(allowedChars.Length)]);
        }

        return sb.ToString();
    }
}