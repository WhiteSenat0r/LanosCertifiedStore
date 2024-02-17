using Application.Commands.Vehicles.DeleteVehicle;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;
using Moq;

namespace UnitTests.Application.Commands.Vehicles;

public class DeleteVehicleCommandTest
{
    private readonly Mock<IRepository<Vehicle>> vehicleRepositoryMock = new();
    private readonly Mock<IUnitOfWork> unitOfWorkMock = new();

    [Fact]
    public async Task Handle_Should_ReturnFailureResult_IfVehicleIsNull()
    {
        // Arrange
        var command = new DeleteVehicleCommand(Guid.NewGuid());

        vehicleRepositoryMock.Setup(x =>
                x.GetEntityByIdAsync(It.IsAny<VehicleByIdQuerySpecification>()))
            .ReturnsAsync((Vehicle)null!);

        var handler = new DeleteVehicleCommandHandler(vehicleRepositoryMock.Object, unitOfWorkMock.Object);

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
        var command = new DeleteVehicleCommand(Guid.NewGuid());

        vehicleRepositoryMock.Setup(x =>
                x.GetEntityByIdAsync(It.IsAny<VehicleByIdQuerySpecification>()))
            .ReturnsAsync(VehicleService.GetVehicle(VehicleService.GetActionVehicleDto()));

        unitOfWorkMock.Setup(x => x.SaveChangesAsync(default))
            .ReturnsAsync(1);

        var handler = new DeleteVehicleCommandHandler(vehicleRepositoryMock.Object, unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert 
        Assert.True(result.IsSuccess);
        Assert.IsType<Result<Unit>>(result);
    }
}