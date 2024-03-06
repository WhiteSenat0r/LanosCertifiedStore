using API.Controllers.Common;
using API.Responses;
using Application.Commands.Vehicles.AddImageToVehicle;
using Application.Commands.Vehicles.CreateVehicle;
using Application.Commands.Vehicles.DeleteVehicle;
using Application.Commands.Vehicles.RemoveImageFromVehicle;
using Application.Commands.Vehicles.SetVehicleMainImage;
using Application.Commands.Vehicles.UpdateVehicle;
using Application.Core.Results;
using Application.Dtos.Common;
using Application.Dtos.VehicleDtos;
using Application.Queries.Vehicles.CountVehiclesQueryRelated;
using Application.Queries.Vehicles.VehicleDetailsQueryRelated;
using Application.Queries.Vehicles.VehiclePriceRangeQueryRelated;
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
    
    [HttpGet("countItems")]
    [ProducesResponseType(typeof(ItemsCountDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ItemsCountDto>> GetItemsCount(
        [FromQuery] VehicleFilteringRequestParameters requestParameters)
    {
        return HandleResult(await Mediator.Send(new CountVehiclesQuery(requestParameters)));
    }
    
    [HttpGet("getPriceRange")]
    [ProducesResponseType(typeof(IDictionary<string, decimal>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ItemsCountDto>> GetPriceRange(
        [FromQuery] VehicleFilteringRequestParameters requestParameters)
    {
        return HandleResult(await Mediator.Send(new VehiclePriceRangeQuery(requestParameters)));
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Guid>> CreateVehicle([FromBody] CreateVehicleCommand createVehicleCommand)
    {
        return HandleResult(await Mediator.Send(createVehicleCommand));
    }

    [HttpPut]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateVehicle([FromBody] UpdateVehicleCommand updateVehicleCommand)
    {
        return HandleResult(await Mediator.Send(updateVehicleCommand));
    }

    [HttpDelete]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> DeleteVehicle([FromBody] DeleteVehicleCommand deleteVehicleCommand)
    {
        return HandleResult(await Mediator.Send(deleteVehicleCommand));
    }

    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [HttpPost("addImage")]
    public async Task<ActionResult> AddImageToVehicle([FromForm] AddImageToVehicleCommand addImageToVehicleCommand)
    {
        return HandleResult(await Mediator.Send(addImageToVehicleCommand));
    }

    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [HttpDelete("deleteImage")]
    public async Task<ActionResult> DeleteImageFromVehicle(
        [FromBody] RemoveImageFromVehicleCommand removeImageFromVehicleCommand)
    {
        return HandleResult(await Mediator.Send(removeImageFromVehicleCommand));
    }

    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [HttpPost("setMainImage")]
    public async Task<ActionResult> SetVehicleMainImage(
        [FromBody] SetVehicleMainImageCommand setVehicleMainImageCommand)
    {
        return HandleResult(await Mediator.Send(setVehicleMainImageCommand));
    }
}