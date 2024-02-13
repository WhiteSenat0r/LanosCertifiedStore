using Application.Commands.Models.DeleteModel;
using Application.Core;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;
using Moq;

namespace UnitTests.Application.Commands.Models;

public class DeleteModelCommandTest
{
    private readonly Mock<IRepository<VehicleModel>> modelRepositoryMock = new();
    private readonly Mock<IUnitOfWork> unitOfWorkMock = new();

    private const string ModelName = "testModel";
    private const string BrandName = "test brand";

    private VehicleBrand VehicleBrand { get; } = new VehicleBrand(BrandName);

    [Fact]
    public async Task Handle_Should_ReturnFailureResult_IfModelIsNull()
    {
        // Arrange
        var command = new DeleteModelCommand(ModelName);

        modelRepositoryMock.Setup(x =>
                x.GetEntityByIdAsync(It.IsAny<ModelByNameQuerySpecification>()))
            .ReturnsAsync((VehicleModel)null!);

        var handler = new DeleteModelCommandHandler(modelRepositoryMock.Object, unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.IsType<Result<Unit>>(result);
    }

    [Fact]
    public async Task Handle_Should_ReturnSuccessResult_IfModelIsNotNull()
    {
        // Arrange
        var command = new DeleteModelCommand(ModelName);

        modelRepositoryMock.Setup(x =>
                x.GetEntityByIdAsync(It.IsAny<ModelByNameQuerySpecification>()))
            .ReturnsAsync(new VehicleModel(VehicleBrand.Id, ModelName));

        unitOfWorkMock.Setup(x => x.SaveChangesAsync(default))
            .ReturnsAsync(1);

        var handler = new DeleteModelCommandHandler(modelRepositoryMock.Object, unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.IsType<Result<Unit>>(result);
    }
}