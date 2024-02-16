using Application.Commands.Displacements.CreateDisplacement;
using Application.Core;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;
using Moq;

namespace UnitTests.Application.Commands.Displacements;

public class CreateDisplacementCommandTest
{
    private readonly Mock<IRepository<VehicleDisplacement>> displacementRepositoryMock = new();
    private readonly Mock<IUnitOfWork> unitOfWorkMock = new();
    
    private const double DisplacementValue = 2.0;
    
    [Fact]
    public async Task Handle_Should_ReturnFailureResult_IfDisplacementAlreadyExists()
    {
        // Arrange

        var command = new CreateDisplacementCommand(DisplacementValue);
        
        displacementRepositoryMock.Setup(x =>
                x.GetEntityByIdAsync(It.IsAny<DisplacementByValueQuerySpecification>()))
            .ReturnsAsync(new VehicleDisplacement(DisplacementValue));

        var handler = new CreateDisplacementCommandHandler(unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert 
        Assert.False(result.IsSuccess);
        Assert.IsType<Result<Unit>>(result);
    }

    [Fact]
    public async Task Handle_Should_ReturnSuccessResult_IfDisplacementDoesNotExists()
    {
        // Arrange
        var command = new CreateDisplacementCommand(DisplacementValue);

        displacementRepositoryMock.Setup(x =>
                x.GetEntityByIdAsync(It.IsAny<DisplacementByValueQuerySpecification>()))
            .ReturnsAsync((VehicleDisplacement)null!);

        unitOfWorkMock.Setup(x => x.SaveChangesAsync(default)).ReturnsAsync(1);

        var handler = new CreateDisplacementCommandHandler(unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert 
        Assert.True(result.IsSuccess);
        Assert.IsType<Result<Unit>>(result);
    }
}