using Application.Commands.Models.CreateModel;
using Application.Core;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;
using Moq;

namespace UnitTests.Application.Commands.Models;

public class CreateModelCommandTest
{
    private readonly Mock<IRepository<VehicleModel>> modelRepositoryMock = new();
    private readonly Mock<IUnitOfWork> unitOfWorkMock = new();
    
    private const string ModelName = "test color";
    private const string BrandName = "test brand";

    private VehicleBrand VehicleBrand { get; } = new VehicleBrand(BrandName);
    
    [Fact]
    public async Task Handle_Should_ReturnFailureResult_IfModelAlreadyExists()
    {
        var command = new CreateModelCommand(VehicleBrand.Id, ModelName);
        
        modelRepositoryMock.Setup(x =>
                x.GetEntityByIdAsync(It.IsAny<ModelByNameQuerySpecification>()))
            .ReturnsAsync(new VehicleModel(VehicleBrand.Id, ModelName));

        var handler = new CreateModelCommandHandler(modelRepositoryMock.Object, unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert 
        Assert.False(result.IsSuccess);
        Assert.IsType<Result<Unit>>(result);
    }

    [Fact]
    public async Task Handle_Should_ReturnSuccessResult_IfModelDoesNotExists()
    {
        // Arrange
        var command = new CreateModelCommand(VehicleBrand.Id, ModelName);

        modelRepositoryMock.Setup(x =>
                x.GetEntityByIdAsync(It.IsAny<ModelQuerySpecification>()))
            .ReturnsAsync((VehicleModel)null!);

        unitOfWorkMock.Setup(x => x.SaveChangesAsync(default)).ReturnsAsync(1);

        var handler = new CreateModelCommandHandler(modelRepositoryMock.Object, unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert 
        Assert.True(result.IsSuccess);
        Assert.IsType<Result<Unit>>(result);
    }
}