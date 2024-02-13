using Application.Commands.Types.CreateType;
using Application.Core;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;
using Moq;

namespace UnitTests.Application.Commands.Types;

public class CreateTypeCommandTest
{
    private readonly Mock<IRepository<VehicleType>> typeRepositoryMock = new();
    private readonly Mock<IUnitOfWork> unitOfWorkMock = new();
    
    private const string TypeName = "test type";
    
    [Fact]
    public async Task Handle_Should_ReturnFailureResult_IfTypeAlreadyExists()
    {
        // Arrange

        var command = new CreateTypeCommand(TypeName);
        
        typeRepositoryMock.Setup(x =>
                x.GetEntityByIdAsync(It.IsAny<TypeByNameQuerySpecification>()))
            .ReturnsAsync(new VehicleType(TypeName));

        var handler = new CreateTypeCommandHandler(typeRepositoryMock.Object, unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert 
        Assert.False(result.IsSuccess);
        Assert.IsType<Result<Unit>>(result);
    }

    [Fact]
    public async Task Handle_Should_ReturnSuccessResult_IfTypeDoesNotExists()
    {
        // Arrange
        var command = new CreateTypeCommand(TypeName);

        typeRepositoryMock.Setup(x =>
                x.GetEntityByIdAsync(It.IsAny<TypeByNameQuerySpecification>()))
            .ReturnsAsync((VehicleType)null!);

        unitOfWorkMock.Setup(x => x.SaveChangesAsync(default)).ReturnsAsync(1);

        var handler = new CreateTypeCommandHandler(typeRepositoryMock.Object, unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert 
        Assert.True(result.IsSuccess);
        Assert.IsType<Result<Unit>>(result);
    }
}