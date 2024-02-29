using API.Controllers.Common;
using API.Responses;
using Application.Commands.Vehicles.CreateVehicle;
using Application.Commands.Vehicles.DeleteVehicle;
using Application.Commands.Vehicles.UpdateVehicle;
using Application.Core.Results;
using Application.Dtos.VehicleDtos;
using Application.Queries.Vehicles.VehicleDetailsQueryRelated;
using Application.Queries.Vehicles.VehiclesQueryRelated;
using Application.RequestParams;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.VehiclesRelated;

public sealed class VehiclesController : BaseEntityRelatedApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(PaginationResult<VehicleDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginationResult<VehicleDto>>> GetVehicles(
        [FromQuery] VehicleFilteringRequestParameters requestParameters)
    {
        return HandleResult(await Mediator.Send(new VehiclesQuery(requestParameters)));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(SingleVehicleDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SingleVehicleDto>> GetVehicle(Guid id)
    {
        return HandleResult(await Mediator.Send(new VehicleDetailsQuery(id)));
    }

    [HttpPost]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> CreateVehicle([FromBody] CreateVehicleCommand createVehicleCommand)
    {
        return HandleResult(await Mediator.Send(createVehicleCommand));
    }

    [HttpPut]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateVehicle([FromBody] UpdateVehicleCommand updateVehicleCommand)
    {
        return HandleResult(await Mediator.Send(updateVehicleCommand));
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> DeleteVehicle(Guid id)
    {
        return HandleResult(await Mediator.Send(new DeleteVehicleCommand(id)));
    }
}