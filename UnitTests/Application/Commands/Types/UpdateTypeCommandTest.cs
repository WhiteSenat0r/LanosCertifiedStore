using Application.Commands.Types.UpdateType;
using Application.Dtos.TypeDtos;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;
using Moq;

namespace UnitTests.Application.Commands.Types;

public class UpdateTypeCommandTest
{
    private readonly Mock<IRepository<VehicleType>> brandRepositoryMock = new();
    private readonly Mock<IUnitOfWork> unitOfWorkMock = new();

    private readonly UpdateTypeDto updateTypeDto = new()
    {
        CurrentName = "testCurrentName",
        UpdatedName = "testUpdatedName"
    };

    [Fact]
    public async Task Handle_Should_ReturnFailureResult_IfTypeWithCurrentNameIsNull()
    {
        // Arrange
        var command = new UpdateTypeCommand(updateTypeDto);

        brandRepositoryMock.Setup(x =>
                x.GetEntityByIdAsync(It.IsAny<TypeByNameQuerySpecification>()))
            .ReturnsAsync((VehicleType)null!);

        var handler = new UpdateTypeCommandHandler(brandRepositoryMock.Object, unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.IsType<Result<Unit>>(result);
    }

    [Fact]
    public async Task Handle_Should_ReturnFailureResult_IfTypeWithUpdatedNameIsNotNull()
    {
        // Arrange
        var command = new UpdateTypeCommand(updateTypeDto);

        brandRepositoryMock.SetupSequence(x =>
                x.GetEntityByIdAsync(It.IsAny<TypeByNameQuerySpecification>()))
            .ReturnsAsync(new VehicleType(updateTypeDto.CurrentName))
            .ReturnsAsync(new VehicleType(updateTypeDto.UpdatedName));

        var handler = new UpdateTypeCommandHandler(brandRepositoryMock.Object, unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.IsType<Result<Unit>>(result);
    }

    [Fact]
    public async Task Handle_Should_ReturnSuccessResult_IfTypeIsNotNullAndTypeWithUpdatedNameDoesNotExists()
    {
        // Arrange
        var command = new UpdateTypeCommand(updateTypeDto);

        brandRepositoryMock.SetupSequence(x =>
                x.GetEntityByIdAsync(It.IsAny<TypeByNameQuerySpecification>()))
            .ReturnsAsync(new VehicleType(updateTypeDto.CurrentName))
            .ReturnsAsync((VehicleType)null!);
        
        unitOfWorkMock.Setup(x => x.SaveChangesAsync(default)).ReturnsAsync(1);
        
        var handler = new UpdateTypeCommandHandler(brandRepositoryMock.Object, unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.IsType<Result<Unit>>(result);
    }
}