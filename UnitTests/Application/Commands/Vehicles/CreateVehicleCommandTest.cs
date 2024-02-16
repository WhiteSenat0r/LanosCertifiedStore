using Application.Commands.Vehicles.CreateVehicle;
using Application.Core;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;
using Moq;

namespace UnitTests.Application.Commands.Vehicles;

public class CreateVehicleCommandTest
{
    private readonly Mock<IRepository<Vehicle>> vehicleRepositoryMock = new();
    private readonly Mock<IUnitOfWork> unitOfWorkMock = new();

    [Fact]
    public async Task Handle_Should_ReturnFailureResult_IfVehicleAlreadyExists()
    {
        // Arrange
        var actionVehicleDto = VehicleService.GetActionVehicleDto();
        var command = new CreateVehicleCommand(actionVehicleDto);

        vehicleRepositoryMock.Setup(x =>
                x.GetEntityByIdAsync(It.IsAny<VehicleByIdQuerySpecification>()))
            .ReturnsAsync(VehicleService.GetVehicle(actionVehicleDto));

        var handler = new CreateVehicleCommandHandler(vehicleRepositoryMock.Object, unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert 
        Assert.False(result.IsSuccess);
        Assert.IsType<Result<Unit>>(result);
    }

    [Fact]
    public async Task Handle_Should_ReturnSuccessResult_IfVehicleDoesNotExists()
    {
        // Arrange
        var command = new CreateVehicleCommand(VehicleService.GetActionVehicleDto());

        vehicleRepositoryMock.Setup(x =>
                x.GetEntityByIdAsync(It.IsAny<VehicleByIdQuerySpecification>()))
            .ReturnsAsync((Vehicle)null!);

        unitOfWorkMock.Setup(x => x.SaveChangesAsync(default)).ReturnsAsync(1);

        var handler = new CreateVehicleCommandHandler(vehicleRepositoryMock.Object, unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert 
        Assert.True(result.IsSuccess);
        Assert.IsType<Result<Unit>>(result);
    }
}