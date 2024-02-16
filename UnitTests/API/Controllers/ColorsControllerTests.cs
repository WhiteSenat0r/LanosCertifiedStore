using API.Controllers.VehiclesRelated;
using Application.Commands.Colors.CreateColor;
using Application.Commands.Colors.DeleteColor;
using Application.Commands.Colors.UpdateColor;
using Application.Core;
using Application.Dtos.ColorDtos;
using Application.Queries.Colors;
using Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace UnitTests.API.Controllers;

public class ColorsControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly ColorsController _colorsController;

    public ColorsControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _colorsController = new ColorsController
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
    public async Task GetColors_ReturnsOk_WhenSuccessful()
    {
        // Arrange
        var colors = new List<ColorDto>();
        _mediatorMock.Setup(m => m.Send(
            It.IsAny<ListColorsQuery>(), default))
            .ReturnsAsync(Result<IReadOnlyList<ColorDto>>.Success(colors));

        // Act
        var result = await _colorsController.GetColors() as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        Assert.Equal(colors, result.Value);
    }
    
    [Fact]
    public async Task GetColors_ReturnsBadRequest_WhenResultIsFailure()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(
                It.IsAny<ListColorsQuery>(), default))
            .ReturnsAsync(Result<IReadOnlyList<ColorDto>>.Failure(null));

        // Act
        var result = await _colorsController.GetColors() as BadRequestObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
        Assert.NotNull(result.Value);
    }
    
    [Fact]
    public async Task CreateColor_ReturnsOk_WhenSuccessful()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(
                It.IsAny<CreateColorCommand>(), default))
            .ReturnsAsync(Result<Unit>.Success(new Unit()));

        // Act
        var result = await _colorsController.CreateColor("TestColor") as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
    }
    
    [Fact]
    public async Task CreateColor_ReturnsBadRequest_WhenResultIsFailure()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(
                It.IsAny<CreateColorCommand>(), default))
            .ReturnsAsync(Result<Unit>.Failure(null));

        // Act
        var result = await _colorsController.CreateColor(null) as BadRequestObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
    }
    
    [Fact]
    public async Task UpdateColor_ReturnsOk_WhenSuccessful()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(
                It.IsAny<UpdateColorCommand>(), default))
            .ReturnsAsync(Result<Unit>.Success(new Unit()));

        // Act
        var result = await _colorsController.UpdateColor(
            new UpdateColorDto
        {
            CurrentName = "Test",
            UpdatedName = "TestUpdated"
        }) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
    }
    
    [Fact]
    public async Task UpdateColor_ReturnsBadRequest_WhenResultIsFailure()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(
                It.IsAny<UpdateColorCommand>(), default))
            .ReturnsAsync(Result<Unit>.Failure(null));

        // Act
        var result = await _colorsController.UpdateColor(null) as BadRequestObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
        Assert.NotNull(result.Value);
    }
    
    [Fact]
    public async Task DeleteColor_ReturnsOk_WhenSuccessful()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(
                It.IsAny<DeleteColorCommand>(), default))
            .ReturnsAsync(Result<Unit>.Success(new Unit()));

        // Act
        var result = await _colorsController.DeleteColor("Test") as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
    }
    
    [Fact]
    public async Task DeleteColor_ReturnsBadRequest_WhenResultIsFailure()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(
                It.IsAny<DeleteColorCommand>(), default))
            .ReturnsAsync(Result<Unit>.Failure(null));

        // Act
        var result = await _colorsController.DeleteColor("Test") as BadRequestObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
    }
}