using Application.Commands.Brands.CreateBrand;
using Application.Core;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;
using Moq;

namespace UnitTests.Application.Commands.Brands;

public class CreateBrandCommandTest
{
    private readonly Mock<IRepository<VehicleBrand>> brandRepositoryMock = new();
    private readonly Mock<IUnitOfWork> unitOfWorkMock = new();
    
    private const string BrandName = "test brand";


    [Fact]
    public async Task Handle_Should_ReturnFailureResult_IfBrandAlreadyExists()
    {
        // Arrange

        var command = new CreateBrandCommand(BrandName);
        
        brandRepositoryMock.Setup(x =>
                x.GetEntityByIdAsync(It.IsAny<BrandByNameQuerySpecification>()))
            .ReturnsAsync(new VehicleBrand(BrandName));

        var handler = new CreateBrandCommandHandler(brandRepositoryMock.Object, unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert 
        Assert.False(result.IsSuccess);
        Assert.IsType<Result<Unit>>(result);
    }

    [Fact]
    public async Task Handle_Should_ReturnSuccessResult_IfBrandDoesNotExists()
    {
        // Arrange
        var command = new CreateBrandCommand(BrandName);

        brandRepositoryMock.Setup(x =>
                x.GetEntityByIdAsync(It.IsAny<BrandByNameQuerySpecification>()))
            .ReturnsAsync((VehicleBrand)null!);

        unitOfWorkMock.Setup(x => x.SaveChangesAsync(default)).ReturnsAsync(1);

        var handler = new CreateBrandCommandHandler(brandRepositoryMock.Object, unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert 
        Assert.True(result.IsSuccess);
        Assert.IsType<Result<Unit>>(result);
    }
}