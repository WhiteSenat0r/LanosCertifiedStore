using API.Controllers.VehiclesRelated;
using Application.Commands.Models.CreateModel;
using Application.Commands.Models.DeleteModel;
using Application.Commands.Models.UpdateModel;
using Application.Core;
using Application.Dtos.ModelDtos;
using Application.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace UnitTests.API.Controllers;

public class ModelsControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly ModelsController _modelsController;

    public ModelsControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _modelsController = new ModelsController
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
    public async Task GetModels_ReturnsOk_WhenSuccessful()
    {
        // Arrange
        var Models = new List<ModelDto>();
        _mediatorMock.Setup(m => m.Send(
            It.IsAny<ListModelsQuery>(), default))
            .ReturnsAsync(Result<IReadOnlyList<ModelDto>>.Success(Models));

        // Act
        var result = await _modelsController.GetModels() as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        Assert.Equal(Models, result.Value);
    }
    
    [Fact]
    public async Task GetModels_ReturnsBadRequest_WhenResultIsFailure()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(
                It.IsAny<ListModelsQuery>(), default))
            .ReturnsAsync(Result<IReadOnlyList<ModelDto>>.Failure(null));

        // Act
        var result = await _modelsController.GetModels() as BadRequestObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
        Assert.NotNull(result.Value);
    }
    
    [Fact]
    public async Task CreateModel_ReturnsOk_WhenSuccessful()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(
                It.IsAny<CreateModelCommand>(), default))
            .ReturnsAsync(Result<Unit>.Success(new Unit()));

        // Act
        var result = await _modelsController.CreateModel(Guid.Empty, "TestModel") as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
    }
    
    [Fact]
    public async Task CreateModel_ReturnsBadRequest_WhenResultIsFailure()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(
                It.IsAny<CreateModelCommand>(), default))
            .ReturnsAsync(Result<Unit>.Failure(null));

        // Act
        var result = await _modelsController.CreateModel(Guid.Empty, "TestModel") as BadRequestObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
    }
    
    [Fact]
    public async Task UpdateModel_ReturnsOk_WhenSuccessful()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(
                It.IsAny<UpdateModelCommand>(), default))
            .ReturnsAsync(Result<Unit>.Success(new Unit()));

        // Act
        var result = await _modelsController.UpdateModel(
            new UpdateModelDto
        {
            CurrentName = "Test",
            UpdatedName = "TestUpdated"
        }) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
    }
    
    [Fact]
    public async Task UpdateModel_ReturnsBadRequest_WhenResultIsFailure()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(
                It.IsAny<UpdateModelCommand>(), default))
            .ReturnsAsync(Result<Unit>.Failure(null));

        // Act
        var result = await _modelsController.UpdateModel(null) as BadRequestObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
        Assert.NotNull(result.Value);
    }
    
    [Fact]
    public async Task DeleteModel_ReturnsOk_WhenSuccessful()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(
                It.IsAny<DeleteModelCommand>(), default))
            .ReturnsAsync(Result<Unit>.Success(new Unit()));

        // Act
        var result = await _modelsController.DeleteModel("Test") as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
    }
    
    [Fact]
    public async Task DeleteModel_ReturnsBadRequest_WhenResultIsFailure()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(
                It.IsAny<DeleteModelCommand>(), default))
            .ReturnsAsync(Result<Unit>.Failure(null));

        // Act
        var result = await _modelsController.DeleteModel("Test") as BadRequestObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
    }
}