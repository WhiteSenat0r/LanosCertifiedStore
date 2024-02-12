using Application.Commands.Brands.DeleteBrand;
using Application.Core;
using Application.QuerySpecifications.BrandRelated;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;
using Moq;

namespace UnitTests.Application.Commands.Brands;

public class DeleteBrandCommandTest
{
    private readonly Mock<IRepository<VehicleBrand>> brandRepositoryMock = new();
    private readonly Mock<IUnitOfWork> unitOfWorkMock = new();

    private const string BrandName = "testBrand";

    [Fact]
    public async Task Handle_Should_ReturnFailureResult_IfBrandIsNull()
    {
        // Arrange
        var command = new DeleteBrandCommand(BrandName);

        brandRepositoryMock.Setup(x =>
                x.GetSingleEntityBySpecificationAsync(It.IsAny<BrandByNameQuerySpecification>()))
            .ReturnsAsync((VehicleBrand)null!);

        var handler = new DeleteBrandCommandHandler(brandRepositoryMock.Object, unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.IsType<Result<Unit>>(result);
    }
    
    [Fact]
    public async Task Handle_Should_ReturnSuccessResult_IfBrandIsNotNull()
    {
        // Arrange
        var command = new DeleteBrandCommand(BrandName);

        brandRepositoryMock.Setup(x =>
                x.GetSingleEntityBySpecificationAsync(It.IsAny<BrandByNameQuerySpecification>()))
            .ReturnsAsync(new VehicleBrand(BrandName));

        unitOfWorkMock.Setup(x => x.SaveChangesAsync(default))
            .ReturnsAsync(1);

        var handler = new DeleteBrandCommandHandler(brandRepositoryMock.Object, unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.IsType<Result<Unit>>(result);
    }
}