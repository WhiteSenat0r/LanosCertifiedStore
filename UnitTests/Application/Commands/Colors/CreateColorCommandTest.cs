using Application.Commands.Colors.CreateColor;
using Application.Core;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;
using Moq;

namespace UnitTests.Application.Commands.Colors;

public class CreateColorCommandTest
{
    private readonly Mock<IRepository<VehicleColor>> colorRepositoryMock = new();
    private readonly Mock<IUnitOfWork> unitOfWorkMock = new();
    
    private const string ColorName = "test color";
    
    [Fact]
    public async Task Handle_Should_ReturnFailureResult_IfColorAlreadyExists()
    {
        // Arrange

        var command = new CreateColorCommand(ColorName);
        
        colorRepositoryMock.Setup(x =>
                x.GetEntityByIdAsync(It.IsAny<ColorByNameQuerySpecification>()))
            .ReturnsAsync(new VehicleColor(ColorName));

        var handler = new CreateColorCommandHandler(colorRepositoryMock.Object, unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert 
        Assert.False(result.IsSuccess);
        Assert.IsType<Result<Unit>>(result);
    }

    [Fact]
    public async Task Handle_Should_ReturnSuccessResult_IfColorDoesNotExists()
    {
        // Arrange
        var command = new CreateColorCommand(ColorName);

        colorRepositoryMock.Setup(x =>
                x.GetEntityByIdAsync(It.IsAny<ColorByNameQuerySpecification>()))
            .ReturnsAsync((VehicleColor)null!);

        unitOfWorkMock.Setup(x => x.SaveChangesAsync(default)).ReturnsAsync(1);

        var handler = new CreateColorCommandHandler(colorRepositoryMock.Object, unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert 
        Assert.True(result.IsSuccess);
        Assert.IsType<Result<Unit>>(result);
    }
}