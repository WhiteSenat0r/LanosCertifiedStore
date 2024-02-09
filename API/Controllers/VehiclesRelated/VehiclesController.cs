using API.Controllers.Common;
using API.Responses;
using Application.Commands.Vehicles.CreateVehicle;
using Application.Commands.Vehicles.DeleteVehicle;
using Application.Commands.Vehicles.UpdateVehicle;
using Application.Core;
using Application.Dtos.VehicleDtos;
using Application.Queries.Vehicles.ListVehicles;
using Application.Queries.Vehicles.VehicleDetails;
using Application.RequestParams;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.VehiclesRelated;

public sealed class VehiclesController : BaseEntityRelatedApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(Result<PaginationResult<VehicleDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetVehicles([FromQuery] VehicleRequestParameters requestParameters)
    {
        return HandleResult(await Mediator.Send(new ListVehiclesQuery(requestParameters)));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(Result<VehicleDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetVehicle(Guid id)
    {
        return HandleResult(await Mediator.Send(new VehicleDetailsQuery(id)));
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(Result<Unit>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateVehicle([FromBody] ActionVehicleDto vehicle)
    {
        return HandleResult(await Mediator.Send(new CreateVehicleCommand(vehicle)));
    }
    
    [HttpPut]
    [ProducesResponseType(typeof(Result<Unit>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateVehicle([FromBody] ActionVehicleDto vehicle)
    {
        return HandleResult(await Mediator.Send(new UpdateVehicleCommand(vehicle)));
    }
    
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(Result<Unit>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteVehicle(Guid id)
    {
        return HandleResult(await Mediator.Send(new DeleteVehicleCommand(id)));
    }
}