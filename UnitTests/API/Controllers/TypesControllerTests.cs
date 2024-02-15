using API.Controllers.VehiclesRelated;
using Application.Commands.Types.CreateType;
using Application.Commands.Types.DeleteType;
using Application.Commands.Types.UpdateType;
using Application.Core;
using Application.Dtos.TypeDtos;
using Application.Queries.Types;
using Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace UnitTests.API.Controllers;

public class TypesControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly TypesController _typesController;

    public TypesControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _typesController = new TypesController
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
    public async Task GetTypes_ReturnsOk_WhenSuccessful()
    {
        // Arrange
        var types = new List<TypeDto>();
        _mediatorMock.Setup(m => m.Send(
            It.IsAny<ListTypesQuery>(), default))
            .ReturnsAsync(Result<IReadOnlyList<TypeDto>>.Success(types));

        // Act
        var result = await _typesController.GetTypes() as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        Assert.Equal(types, result.Value);
    }
    
    [Fact]
    public async Task GetTypes_ReturnsBadRequest_WhenResultIsFailure()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(
                It.IsAny<ListTypesQuery>(), default))
            .ReturnsAsync(Result<IReadOnlyList<TypeDto>>.Failure(null));

        // Act
        var result = await _typesController.GetTypes() as BadRequestObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
        Assert.NotNull(result.Value);
    }
    
    [Fact]
    public async Task CreateType_ReturnsOk_WhenSuccessful()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(
                It.IsAny<CreateTypeCommand>(), default))
            .ReturnsAsync(Result<Unit>.Success(new Unit()));

        // Act
        var result = await _typesController.CreateType("TestType") as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
    }
    
    [Fact]
    public async Task CreateType_ReturnsBadRequest_WhenResultIsFailure()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(
                It.IsAny<CreateTypeCommand>(), default))
            .ReturnsAsync(Result<Unit>.Failure(null));

        // Act
        var result = await _typesController.CreateType(null) as BadRequestObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
    }
    
    [Fact]
    public async Task UpdateType_ReturnsOk_WhenSuccessful()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(
                It.IsAny<UpdateTypeCommand>(), default))
            .ReturnsAsync(Result<Unit>.Success(new Unit()));

        // Act
        var result = await _typesController.UpdateType(
            new UpdateTypeDto
        {
            CurrentName = "Test",
            UpdatedName = "TestUpdated"
        }) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
    }
    
    [Fact]
    public async Task UpdateType_ReturnsBadRequest_WhenResultIsFailure()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(
                It.IsAny<UpdateTypeCommand>(), default))
            .ReturnsAsync(Result<Unit>.Failure(null));

        // Act
        var result = await _typesController.UpdateType(null) as BadRequestObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
        Assert.NotNull(result.Value);
    }
    
    [Fact]
    public async Task DeleteType_ReturnsOk_WhenSuccessful()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(
                It.IsAny<DeleteTypeCommand>(), default))
            .ReturnsAsync(Result<Unit>.Success(new Unit()));

        // Act
        var result = await _typesController.DeleteType("Test") as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
    }
    
    [Fact]
    public async Task DeleteType_ReturnsBadRequest_WhenResultIsFailure()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(
                It.IsAny<DeleteTypeCommand>(), default))
            .ReturnsAsync(Result<Unit>.Failure(null));

        // Act
        var result = await _typesController.DeleteType("Test") as BadRequestObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
    }
}