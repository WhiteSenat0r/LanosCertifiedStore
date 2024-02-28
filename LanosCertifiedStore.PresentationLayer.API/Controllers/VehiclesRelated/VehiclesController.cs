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
    [ProducesResponseType(typeof(PaginationResult<DetailsVehicleDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginationResult<DetailsVehicleDto>>> GetVehicles(
        [FromQuery] VehicleFilteringRequestParameters requestParameters)
    {
        return HandleResult(await Mediator.Send(new ListVehiclesQuery(requestParameters)));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(DetailsVehicleDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DetailsVehicleDto>> GetVehicle(Guid id)
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
    public async Task<ActionResult> UpdateVehicle([FromForm] string serializedVehicleData,
        [FromForm] List<IFormFile>? uploadedImages,
        [FromForm] string? mainImageName, 
        [FromForm] Guid? mainImageId)
    {
        return HandleResult(await Mediator.Send(
            new UpdateVehicleCommand(
                JsonSerializer.Deserialize<UpdateVehicleDto>(serializedVehicleData)!,
                uploadedImages, mainImageName, mainImageId)));
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> DeleteVehicle(Guid id)
    {
        return HandleResult(await Mediator.Send(new DeleteVehicleCommand(id)));
    }
}