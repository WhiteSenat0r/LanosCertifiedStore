using Application.Commands.Types.DeleteType;
using Application.Core;
using Application.QuerySpecifications.TypeRelated;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;
using Moq;

namespace UnitTests.Application.Commands.Types;

public class DeleteTypeCommandTest
{
    private readonly Mock<IRepository<VehicleType>> brandRepositoryMock = new();
    private readonly Mock<IUnitOfWork> unitOfWorkMock = new();

    private const string TypeName = "testType";

    [Fact]
    public async Task Handle_Should_ReturnFailureResult_IfTypeIsNull()
    {
        // Arrange
        var command = new DeleteTypeCommand(TypeName);

        brandRepositoryMock.Setup(x =>
                x.GetSingleEntityBySpecificationAsync(It.IsAny<TypeByNameQuerySpecification>()))
            .ReturnsAsync((VehicleType)null!);

        var handler = new DeleteTypeCommandHandler(brandRepositoryMock.Object, unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.IsType<Result<Unit>>(result);
    }

    [Fact]
    public async Task Handle_Should_ReturnSuccessResult_IfTypeIsNotNull()
    {
        // Arrange
        var command = new DeleteTypeCommand(TypeName);

        brandRepositoryMock.Setup(x =>
                x.GetSingleEntityBySpecificationAsync(It.IsAny<TypeByNameQuerySpecification>()))
            .ReturnsAsync(new VehicleType(TypeName));

        unitOfWorkMock.Setup(x => x.SaveChangesAsync(default))
            .ReturnsAsync(1);

        var handler = new DeleteTypeCommandHandler(brandRepositoryMock.Object, unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.IsType<Result<Unit>>(result);
    }
}