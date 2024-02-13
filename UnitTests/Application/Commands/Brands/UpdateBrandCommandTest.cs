using Application.Commands.Brands.UpdateBrand;
using Application.Core;
using Application.Dtos.BrandDtos;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;
using Moq;

namespace UnitTests.Application.Commands.Brands;

public class UpdateBrandCommandTest
{
    private readonly Mock<IRepository<VehicleBrand>> brandRepositoryMock = new();
    private readonly Mock<IUnitOfWork> unitOfWorkMock = new();

    private readonly UpdateBrandDto updateBrandDto = new()
    {
        CurrentName = "testCurrentName",
        UpdatedName = "testUpdatedName"
    };

    [Fact]
    public async Task Handle_Should_ReturnFailureResult_IfBrandWithCurrentNameIsNull()
    {
        // Arrange
        var command = new UpdateBrandCommand(updateBrandDto);

        brandRepositoryMock.Setup(x =>
                x.GetEntityByIdAsync(It.IsAny<BrandByNameQuerySpecification>()))
            .ReturnsAsync((VehicleBrand)null!);

        var handler = new UpdateBrandCommandHandler(brandRepositoryMock.Object, unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.IsType<Result<Unit>>(result);
    }

    [Fact]
    public async Task Handle_Should_ReturnFailureResult_IfBrandWithUpdatedNameIsNotNull()
    {
        // Arrange
        var command = new UpdateBrandCommand(updateBrandDto);

        brandRepositoryMock.SetupSequence(x =>
                x.GetEntityByIdAsync(It.IsAny<BrandByNameQuerySpecification>()))
            .ReturnsAsync(new VehicleBrand(updateBrandDto.CurrentName))
            .ReturnsAsync(new VehicleBrand(updateBrandDto.UpdatedName));

        var handler = new UpdateBrandCommandHandler(brandRepositoryMock.Object, unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.IsType<Result<Unit>>(result);
    }

    [Fact]
    public async Task Handle_Should_ReturnSuccessResult_IfBrandIsNotNullAndBrandWithUpdatedNameDoesNotExists()
    {
        // Arrange
        var command = new UpdateBrandCommand(updateBrandDto);

        brandRepositoryMock.SetupSequence(x =>
                x.GetEntityByIdAsync(It.IsAny<BrandByNameQuerySpecification>()))
            .ReturnsAsync(new VehicleBrand(updateBrandDto.CurrentName))
            .ReturnsAsync((VehicleBrand)null!);
        
        unitOfWorkMock.Setup(x => x.SaveChangesAsync(default)).ReturnsAsync(1);
        
        var handler = new UpdateBrandCommandHandler(brandRepositoryMock.Object, unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.IsType<Result<Unit>>(result);
    }
}