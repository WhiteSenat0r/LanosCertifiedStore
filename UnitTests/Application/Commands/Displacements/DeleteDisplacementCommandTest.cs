using Application.Commands.Displacements.DeleteDisplacement;
using Application.Core;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;
using Moq;

namespace UnitTests.Application.Commands.Displacements;

public class DeleteDisplacementCommandTest
{
    private readonly Mock<IRepository<VehicleDisplacement>> displacementRepositoryMock = new();
    private readonly Mock<IUnitOfWork> unitOfWorkMock = new();

    private const double DisplacementValue = 2.0;

    [Fact]
    public async Task Handle_Should_ReturnFailureResult_IfDisplacementIsNull()
    {
        // Arrange
        var command = new DeleteDisplacementCommand(DisplacementValue);

        displacementRepositoryMock.Setup(x =>
                x.GetEntityByIdAsync(It.IsAny<DisplacementByValueQuerySpecification>()))
            .ReturnsAsync((VehicleDisplacement)null!);

        var handler = new DeleteDisplacementCommandHandler(displacementRepositoryMock.Object, unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.IsType<Result<Unit>>(result);
    }
    
    [Fact]
    public async Task Handle_Should_ReturnSuccessResult_IfDisplacementIsNotNull()
    {
        // Arrange
        var command = new DeleteDisplacementCommand(DisplacementValue);

        displacementRepositoryMock.Setup(x =>
                x.GetEntityByIdAsync(It.IsAny<DisplacementByValueQuerySpecification>()))
            .ReturnsAsync(new VehicleDisplacement(DisplacementValue));

        unitOfWorkMock.Setup(x => x.SaveChangesAsync(default))
            .ReturnsAsync(1);

        var handler = new DeleteDisplacementCommandHandler(displacementRepositoryMock.Object, unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.IsType<Result<Unit>>(result);
    }
}