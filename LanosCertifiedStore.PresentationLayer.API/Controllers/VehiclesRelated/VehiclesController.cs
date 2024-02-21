using System.Text.Json;
using API.Controllers.Common;
using API.Responses;
using Application.Commands.Vehicles.CreateVehicle;
using Application.Commands.Vehicles.DeleteVehicle;
using Application.Commands.Vehicles.UpdateVehicle;
using Application.Core.Results;
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
    [ProducesResponseType(typeof(PaginationResult<VehicleDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginationResult<VehicleDto>>> GetVehicles(
        [FromQuery] VehicleFilteringRequestParameters requestParameters)
    {
        return HandleResult(await Mediator.Send(new ListVehiclesQuery(requestParameters)));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(VehicleDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<VehicleDto>> GetVehicle(Guid id)
    {
        return HandleResult(await Mediator.Send(new VehicleDetailsQuery(id)));
    }

    [HttpPost]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> CreateVehicle([FromForm] string serializedVehicleData,
        [FromForm] List<IFormFile> uploadedImages, [FromForm] string mainImageName)
    {
        return HandleResult(await Mediator.Send(
                new CreateVehicleCommand(
                    JsonSerializer.Deserialize<ActionVehicleDto>(serializedVehicleData)!,
                    uploadedImages, mainImageName)));
    }

    [HttpPut]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateVehicle([FromBody] ActionVehicleDto vehicle)
    {
        return HandleResult(await Mediator.Send(new UpdateVehicleCommand(vehicle)));
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> DeleteVehicle(Guid id)
    {
        return HandleResult(await Mediator.Send(new DeleteVehicleCommand(id)));
    }
}