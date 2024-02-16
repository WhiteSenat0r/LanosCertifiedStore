using Application.Commands.Colors.UpdateColor;
using Application.Core;
using Application.Dtos.ColorDtos;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;
using Moq;

namespace UnitTests.Application.Commands.Colors;

public class UpdateColorCommandTest
{
    private readonly Mock<IRepository<VehicleColor>> colorRepositoryMock = new();
    private readonly Mock<IUnitOfWork> unitOfWorkMock = new();

    private readonly UpdateColorDto updateColorDto = new()
    {
        CurrentName = "testCurrentName",
        UpdatedName = "testUpdatedName"
    };

    [Fact]
    public async Task Handle_Should_ReturnFailureResult_IfColorWithCurrentNameIsNull()
    {
        // Arrange
        var command = new UpdateColorCommand(updateColorDto);

        colorRepositoryMock.Setup(x =>
                x.GetEntityByIdAsync(It.IsAny<ColorByNameQuerySpecification>()))
            .ReturnsAsync((VehicleColor)null!);

        var handler = new UpdateColorCommandHandler(colorRepositoryMock.Object, unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.IsType<Result<Unit>>(result);
    }

    [Fact]
    public async Task Handle_Should_ReturnFailureResult_IfColorWithUpdatedNameIsNotNull()
    {
        // Arrange
        var command = new UpdateColorCommand(updateColorDto);

        colorRepositoryMock.SetupSequence(x =>
                x.GetEntityByIdAsync(It.IsAny<ColorByNameQuerySpecification>()))
            .ReturnsAsync(new VehicleColor(updateColorDto.CurrentName))
            .ReturnsAsync(new VehicleColor(updateColorDto.UpdatedName));

        var handler = new UpdateColorCommandHandler(colorRepositoryMock.Object, unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.IsType<Result<Unit>>(result);
    }

    [Fact]
    public async Task Handle_Should_ReturnSuccessResult_IfColorIsNotNullAndColorWithUpdatedNameDoesNotExists()
    {
        // Arrange
        var command = new UpdateColorCommand(updateColorDto);

        colorRepositoryMock.SetupSequence(x =>
                x.GetEntityByIdAsync(It.IsAny<ColorByNameQuerySpecification>()))
            .ReturnsAsync(new VehicleColor(updateColorDto.CurrentName))
            .ReturnsAsync((VehicleColor)null!);
        
        unitOfWorkMock.Setup(x => x.SaveChangesAsync(default)).ReturnsAsync(1);
        
        var handler = new UpdateColorCommandHandler(colorRepositoryMock.Object, unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.IsType<Result<Unit>>(result);
    }
}