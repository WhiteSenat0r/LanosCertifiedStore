using Application.Commands.Displacements.UpdateDisplacement;
using Application.Core;
using Application.Dtos.DisplacementDtos;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;
using Moq;

namespace UnitTests.Application.Commands.Displacements;

public class UpdateDisplacementCommandTest
{
    private readonly Mock<IRepository<VehicleDisplacement>> displacementRepositoryMock = new();
    private readonly Mock<IUnitOfWork> unitOfWorkMock = new();

    private readonly UpdateDisplacementDto updateDisplacementDto = new()
    {
        CurrentValue = 2.0,
        UpdatedValue = 2.5
    };

    [Fact]
    public async Task Handle_Should_ReturnFailureResult_IfDisplacementWithCurrentNameIsNull()
    {
        // Arrange
        var command = new UpdateDisplacementCommand(updateDisplacementDto);

        displacementRepositoryMock.Setup(x =>
                x.GetEntityByIdAsync(It.IsAny<DisplacementByValueQuerySpecification>()))
            .ReturnsAsync((VehicleDisplacement)null!);

        var handler = new UpdateDisplacementCommandHandler(unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.IsType<Result<Unit>>(result);
    }

    [Fact]
    public async Task Handle_Should_ReturnFailureResult_IfDisplacementWithUpdatedNameIsNotNull()
    {
        // Arrange
        var command = new UpdateDisplacementCommand(updateDisplacementDto);

        displacementRepositoryMock.SetupSequence(x =>
                x.GetEntityByIdAsync(It.IsAny<DisplacementByValueQuerySpecification>()))
            .ReturnsAsync(new VehicleDisplacement(updateDisplacementDto.CurrentValue))
            .ReturnsAsync(new VehicleDisplacement(updateDisplacementDto.UpdatedValue));

        var handler = new UpdateDisplacementCommandHandler(unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.IsType<Result<Unit>>(result);
    }

    [Fact]
    public async Task Handle_Should_ReturnSuccessResult_IfDisplacementIsNotNullAndDisplacementWithUpdatedNameDoesNotExists()
    {
        // Arrange
        var command = new UpdateDisplacementCommand(updateDisplacementDto);

        displacementRepositoryMock.SetupSequence(x =>
                x.GetEntityByIdAsync(It.IsAny<DisplacementByValueQuerySpecification>()))
            .ReturnsAsync(new VehicleDisplacement(updateDisplacementDto.CurrentValue))
            .ReturnsAsync((VehicleDisplacement)null!);
        
        unitOfWorkMock.Setup(x => x.SaveChangesAsync(default)).ReturnsAsync(1);
        
        var handler = new UpdateDisplacementCommandHandler(unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.IsType<Result<Unit>>(result);
    }
}