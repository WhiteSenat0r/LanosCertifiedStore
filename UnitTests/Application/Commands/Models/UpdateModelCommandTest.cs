using Application.Commands.Models.UpdateModel;
using Application.Core;
using Application.Dtos.ModelDtos;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;
using Moq;

namespace UnitTests.Application.Commands.Models;

public class UpdateModelCommandTest
{
    private readonly Mock<IRepository<VehicleModel>> modelRepositoryMock = new();
    private readonly Mock<IUnitOfWork> unitOfWorkMock = new();

    private readonly UpdateModelDto updateModelDto = new()
    {
        CurrentName = "testCurrentName",
        UpdatedName = "testUpdatedName"
    };

    private const string BrandName = "test brand";

    private VehicleBrand VehicleBrand { get; } = new VehicleBrand(BrandName);

    [Fact]
    public async Task Handle_Should_ReturnFailureResult_IfModelWithCurrentNameIsNull()
    {
        // Arrange
        var command = new UpdateModelCommand(updateModelDto);

        modelRepositoryMock.Setup(x =>
                x.GetEntityByIdAsync(It.IsAny<ModelByNameQuerySpecification>()))
            .ReturnsAsync((VehicleModel)null!);

        var handler = new UpdateModelCommandHandler(modelRepositoryMock.Object, unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.IsType<Result<Unit>>(result);
    }

    [Fact]
    public async Task Handle_Should_ReturnFailureResult_IfModelWithUpdatedNameIsNotNull()
    {
        // Arrange
        var command = new UpdateModelCommand(updateModelDto);

        modelRepositoryMock.SetupSequence(x =>
                x.GetEntityByIdAsync(It.IsAny<ModelByNameQuerySpecification>()))
            .ReturnsAsync(new VehicleModel(VehicleBrand.Id, updateModelDto.CurrentName))
            .ReturnsAsync(new VehicleModel(VehicleBrand.Id, updateModelDto.UpdatedName));

        var handler = new UpdateModelCommandHandler(modelRepositoryMock.Object, unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.IsType<Result<Unit>>(result);
    }

    [Fact]
    public async Task Handle_Should_ReturnSuccessResult_IfModelIsNotNullAndModelWithUpdatedNameDoesNotExists()
    {
        // Arrange
        var command = new UpdateModelCommand(updateModelDto);

        modelRepositoryMock.SetupSequence(x =>
                x.GetEntityByIdAsync(It.IsAny<ModelByNameQuerySpecification>()))
            .ReturnsAsync(new VehicleModel(VehicleBrand.Id, updateModelDto.CurrentName))
            .ReturnsAsync((VehicleModel)null!);

        unitOfWorkMock.Setup(x => x.SaveChangesAsync(default)).ReturnsAsync(1);

        var handler = new UpdateModelCommandHandler(modelRepositoryMock.Object, unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.IsType<Result<Unit>>(result);
    }
}