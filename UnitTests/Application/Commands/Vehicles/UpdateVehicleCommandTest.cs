using Application.Commands.Vehicles.UpdateVehicle;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;
using Moq;

namespace UnitTests.Application.Commands.Vehicles;

public class UpdateVehicleCommandTest
{
    private readonly Mock<IRepository<Vehicle>> vehicleRepositoryMock = new();
    private readonly Mock<IRepository<VehiclePrice>> vehiclePriceRepositoryMock = new();
    private readonly Mock<IUnitOfWork> unitOfWorkMock = new();
    private readonly Mock<IMapper> mapperMock = new();

    [Fact]
    public async Task Handle_Should_ReturnFailureResult_IfVehicleIsNull()
    {
        // Arrange
        var command = new UpdateVehicleCommand(VehicleService.GetActionVehicleDto());

        vehicleRepositoryMock.Setup(x =>
                x.GetEntityByIdAsync(It.IsAny<VehicleByIdQuerySpecification>()))
            .ReturnsAsync((Vehicle)null!);

        var handler = new UpdateVehicleCommandHandler(
            vehicleRepositoryMock.Object,
            vehiclePriceRepositoryMock.Object,
            mapperMock.Object,
            unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert 
        Assert.False(result.IsSuccess);
        Assert.IsType<Result<Unit>>(result);
    }

    [Fact]
    public async Task Handle_Should_ReturnSuccessResult_IfVehicleIsNotNull()
    {
        // Arrange
        var command = new UpdateVehicleCommand(VehicleService.GetActionVehicleDto());

        vehicleRepositoryMock.Setup(x =>
                x.GetEntityByIdAsync(It.IsAny<VehicleByIdQuerySpecification>()))
            .ReturnsAsync(VehicleService.GetVehicle(VehicleService.GetActionVehicleDto()));

        unitOfWorkMock.Setup(x => x.SaveChangesAsync(default))
            .ReturnsAsync(1);

        var handler = new UpdateVehicleCommandHandler(
            vehicleRepositoryMock.Object,
            vehiclePriceRepositoryMock.Object,
            mapperMock.Object,
            unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert 
        Assert.True(result.IsSuccess);
        Assert.IsType<Result<Unit>>(result);
    }
    
    [Fact]
    public async Task Handle_Should_AddNewPrice_IfPriceIsAltered()
    {
        // Arrange
        var command = new UpdateVehicleCommand(VehicleService.GetActionVehicleDto());

        var vehicle = VehicleService.GetVehicle(VehicleService.GetActionVehicleDto());

        vehicle.Prices.Remove(vehicle.Prices.First());
        vehicle.Prices.Add(new VehiclePrice(vehicle.Id, 50000));


        vehicleRepositoryMock.Setup(x =>
                x.GetEntityByIdAsync(It.IsAny<VehicleByIdQuerySpecification>()))
            .ReturnsAsync(vehicle);

        unitOfWorkMock.Setup(x => x.SaveChangesAsync(default))
            .ReturnsAsync(1);
        

        var handler = new UpdateVehicleCommandHandler(
            vehicleRepositoryMock.Object,
            vehiclePriceRepositoryMock.Object,
            mapperMock.Object,
            unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert 
        Assert.True(result.IsSuccess);
        Assert.IsType<Result<Unit>>(result);
    }
}