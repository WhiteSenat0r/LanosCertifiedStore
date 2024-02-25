using Application.Dtos.DisplacementDtos;
using Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace UnitTests.API.Controllers;

public class DisplacementsControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly DisplacementsController _displacementsController;

    public DisplacementsControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _displacementsController = new DisplacementsController
        {
            ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    RequestServices = new ServiceCollection()
                        .AddSingleton(_mediatorMock.Object).BuildServiceProvider()
                }
            }
        };
    }

    [Fact]
    public async Task GetDisplacements_ReturnsOk_WhenSuccessful()
    {
        // Arrange
        var Displacements = new List<DisplacementDto>();
        _mediatorMock.Setup(m => m.Send(
            It.IsAny<ListDisplacementsQuery>(), default))
            .ReturnsAsync(Result<IReadOnlyList<DisplacementDto>>.Success(Displacements));

        // Act
        var result = await _displacementsController.GetDisplacements() as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        Assert.Equal(Displacements, result.Value);
    }
    
    [Fact]
    public async Task GetDisplacements_ReturnsBadRequest_WhenResultIsFailure()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(
                It.IsAny<ListDisplacementsQuery>(), default))
            .ReturnsAsync(Result<IReadOnlyList<DisplacementDto>>.Failure(null));

        // Act
        var result = await _displacementsController.GetDisplacements() as BadRequestObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
        Assert.NotNull(result.Value);
    }
    
    [Fact]
    public async Task CreateDisplacement_ReturnsOk_WhenSuccessful()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(
                It.IsAny<CreateDisplacementCommand>(), default))
            .ReturnsAsync(Result<Unit>.Success(new Unit()));

        // Act
        var result = await _displacementsController.CreateDisplacement(1d) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
    }
    
    [Fact]
    public async Task CreateDisplacement_ReturnsBadRequest_WhenResultIsFailure()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(
                It.IsAny<CreateDisplacementCommand>(), default))
            .ReturnsAsync(Result<Unit>.Failure(null));

        // Act
        var result = await _displacementsController.CreateDisplacement(1d) as BadRequestObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
    }
    
    [Fact]
    public async Task UpdateDisplacement_ReturnsOk_WhenSuccessful()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(
                It.IsAny<UpdateDisplacementCommand>(), default))
            .ReturnsAsync(Result<Unit>.Success(new Unit()));

        // Act
        var result = await _displacementsController.UpdateDisplacement(
            new UpdateDisplacementDto
        {
            CurrentValue = 1d,
            UpdatedValue = 2d
        }) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
    }
    
    [Fact]
    public async Task UpdateDisplacement_ReturnsBadRequest_WhenResultIsFailure()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(
                It.IsAny<UpdateDisplacementCommand>(), default))
            .ReturnsAsync(Result<Unit>.Failure(null));

        // Act
        var result = await _displacementsController.UpdateDisplacement(null) as BadRequestObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
        Assert.NotNull(result.Value);
    }
    
    [Fact]
    public async Task DeleteDisplacement_ReturnsOk_WhenSuccessful()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(
                It.IsAny<DeleteDisplacementCommand>(), default))
            .ReturnsAsync(Result<Unit>.Success(new Unit()));

        // Act
        var result = await _displacementsController.DeleteDisplacement(1d) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
    }
    
    [Fact]
    public async Task DeleteDisplacement_ReturnsBadRequest_WhenResultIsFailure()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(
                It.IsAny<DeleteDisplacementCommand>(), default))
            .ReturnsAsync(Result<Unit>.Failure(null));

        // Act
        var result = await _displacementsController.DeleteDisplacement(1d) as BadRequestObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
    }
}