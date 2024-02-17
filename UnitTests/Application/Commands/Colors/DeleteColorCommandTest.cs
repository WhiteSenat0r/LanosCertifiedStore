using Application.Commands.Colors.DeleteColor;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;
using Moq;

namespace UnitTests.Application.Commands.Colors;

public class DeleteColorCommandTest
{
    private readonly Mock<IRepository<VehicleColor>> colorRepositoryMock = new();
    private readonly Mock<IUnitOfWork> unitOfWorkMock = new();

    private const string ColorName = "testColor";

    [Fact]
    public async Task Handle_Should_ReturnFailureResult_IfColorIsNull()
    {
        // Arrange
        var command = new DeleteColorCommand(ColorName);

        colorRepositoryMock.Setup(x =>
                x.GetEntityByIdAsync(It.IsAny<ColorByNameQuerySpecification>()))
            .ReturnsAsync((VehicleColor)null!);

        var handler = new DeleteColorCommandHandler(colorRepositoryMock.Object, unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.IsType<Result<Unit>>(result);
    }
    
    [Fact]
    public async Task Handle_Should_ReturnSuccessResult_IfColorIsNotNull()
    {
        // Arrange
        var command = new DeleteColorCommand(ColorName);

        colorRepositoryMock.Setup(x =>
                x.GetEntityByIdAsync(It.IsAny<ColorByNameQuerySpecification>()))
            .ReturnsAsync(new VehicleColor(ColorName));

        unitOfWorkMock.Setup(x => x.SaveChangesAsync(default))
            .ReturnsAsync(1);

        var handler = new DeleteColorCommandHandler(colorRepositoryMock.Object, unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.IsType<Result<Unit>>(result);
    }
}