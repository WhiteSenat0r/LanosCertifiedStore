using API.Controllers.VehiclesRelated;
using Application.Commands.Vehicles.CreateVehicle;
using Application.Commands.Vehicles.DeleteVehicle;
using Application.Commands.Vehicles.UpdateVehicle;
using Application.Dtos.VehicleDtos;
using Application.Queries.Vehicles.ListVehicles;
using Application.Queries.Vehicles.VehicleDetails;
using Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace UnitTests.API.Controllers;

public class VehiclesControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly VehiclesController _vehiclesController;

    public VehiclesControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _vehiclesController = new VehiclesController
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
    public async Task GetVehicles_ReturnsOk_WhenSuccessful()
    {
        // Arrange
        var vehicles = new PaginationResult<DetailsVehicleDto>(
            new List<DetailsVehicleDto>(), new VehicleRequestParameters(), 0);
        _mediatorMock.Setup(m => m.Send(
            It.IsAny<ListVehiclesQuery>(), default))
            .ReturnsAsync(Result<PaginationResult<DetailsVehicleDto>>.Success(vehicles));

        // Act
        var result = await _vehiclesController.GetVehicles(new VehicleRequestParameters()) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        Assert.Equal(vehicles, result.Value);
    }
    
    [Fact]
    public async Task GetVehicles_ReturnsBadRequest_WhenResultIsFailure()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(
                It.IsAny<ListVehiclesQuery>(), default))
            .ReturnsAsync(Result<PaginationResult<DetailsVehicleDto>>.Failure(null));

        // Act
        var result = await _vehiclesController.GetVehicles(new VehicleRequestParameters()) as BadRequestObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
        Assert.NotNull(result.Value);
    }
    
    [Fact]
    public async Task GetVehiclesById_ReturnsOk_WhenSuccessful()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(
                It.IsAny<VehicleDetailsQuery>(), default))
            .ReturnsAsync(Result<DetailsVehicleDto>.Success(new DetailsVehicleDto()));

        // Act
        var result = await _vehiclesController.GetVehicle(Guid.Empty) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
    }
    
    [Fact]
    public async Task GetVehiclesById_ReturnsNotFound_WhenIdDoesNotExist()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(
                It.IsAny<VehicleDetailsQuery>(), default))
            .ReturnsAsync(Result<DetailsVehicleDto>.Success(null));

        // Act
        var result = await _vehiclesController.GetVehicle(Guid.Empty) as NotFoundObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status404NotFound, result.StatusCode);
    }
    
    [Fact]
    public async Task GetVehiclesById_ReturnsBadRequest_WhenResultIsFailure()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(
                It.IsAny<VehicleDetailsQuery>(), default))
            .ReturnsAsync(Result<DetailsVehicleDto>.Failure(null));

        // Act
        var result = await _vehiclesController.GetVehicle(Guid.Empty) as BadRequestObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
    }
    
    [Fact]
    public async Task CreateVehicle_ReturnsOk_WhenSuccessful()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(
                It.IsAny<CreateVehicleCommand>(), default))
            .ReturnsAsync(Result<Unit>.Success(new Unit()));

        // Act
        var result = await _vehiclesController.CreateVehicle(new ActionVehicleDto()) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
    }
    
    [Fact]
    public async Task CreateVehicle_ReturnsBadRequest_WhenResultIsFailure()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(
                It.IsAny<CreateVehicleCommand>(), default))
            .ReturnsAsync(Result<Unit>.Failure(null));

        // Act
        var result = await _vehiclesController.CreateVehicle(null) as BadRequestObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
    }
    
    [Fact]
    public async Task UpdateVehicle_ReturnsOk_WhenSuccessful()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(
                It.IsAny<UpdateVehicleCommand>(), default))
            .ReturnsAsync(Result<Unit>.Success(new Unit()));

        // Act
        var result = await _vehiclesController.UpdateVehicle(new ActionVehicleDto()) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
    }
    
    [Fact]
    public async Task UpdateVehicle_ReturnsBadRequest_WhenResultIsFailure()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(
                It.IsAny<UpdateVehicleCommand>(), default))
            .ReturnsAsync(Result<Unit>.Failure(null));

        // Act
        var result = await _vehiclesController.UpdateVehicle(null) as BadRequestObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
        Assert.NotNull(result.Value);
    }
    
    [Fact]
    public async Task DeleteVehicle_ReturnsOk_WhenSuccessful()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(
                It.IsAny<DeleteVehicleCommand>(), default))
            .ReturnsAsync(Result<Unit>.Success(new Unit()));

        // Act
        var result = await _vehiclesController.DeleteVehicle(Guid.Empty) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
    }
    
    [Fact]
    public async Task DeleteVehicle_ReturnsBadRequest_WhenResultIsFailure()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(
                It.IsAny<DeleteVehicleCommand>(), default))
            .ReturnsAsync(Result<Unit>.Failure(null));

        // Act
        var result = await _vehiclesController.DeleteVehicle(Guid.Empty) as BadRequestObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
    }
}