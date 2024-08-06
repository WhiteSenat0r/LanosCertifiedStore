using LanosCertifiedStore.Application.Images.Commands.AddImageToVehicle;
using LanosCertifiedStore.Application.Shared.DtosRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.Shared.ValidationRelated;
using LanosCertifiedStore.Application.Vehicles;
using LanosCertifiedStore.Application.Vehicles.Commands.CreateVehicleCommandRequestRelated;
using LanosCertifiedStore.Application.Vehicles.Commands.DeleteVehicleCommandRequestRelated;
using LanosCertifiedStore.Application.Vehicles.Commands.UpdateVehicleCommandRequestRelated;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using LanosCertifiedStore.Application.Vehicles.Queries.CollectionVehiclesQueryRelated;
using LanosCertifiedStore.Application.Vehicles.Queries.CountVehiclesQueryRelated;
using LanosCertifiedStore.Application.Vehicles.Queries.SingleVehicleQueryRequestRelated;
using LanosCertifiedStore.Application.Vehicles.Queries.VehiclePriceRangeQueryRelated;
using LanosCertifiedStore.Infrastructure.Authorization;
using LanosCertifiedStore.Presentation.Controllers.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LanosCertifiedStore.Presentation.Controllers.VehicleRelated;

[Route("api/vehicles")]
public sealed class VehiclesController : BaseApiController
{
    [AllowAnonymous]
    [HttpGet]
    [ProducesResponseType(typeof(PaginationResult<VehicleDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PaginationResult<VehicleDto>>> GetVehicles(
        [FromQuery] VehicleFilteringRequestParameters requestParameters)
    {
        var result = await Sender.Send(new CollectionVehiclesQueryRequest(requestParameters));

        return Ok(result.Value);
    }

    [AllowAnonymous]
    [HttpGet("{id:guid}", Name = "GetVehicleById")]
    [ProducesResponseType(typeof(SingleVehicleDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SingleVehicleDto>> GetVehicle(Guid id)
    {
        var result = await Sender.Send(new SingleVehicleQueryRequest(id));

        if (!result.IsSuccess)
        {
            return NotFound(CreateNotFoundProblemDetails(result.Error!));
        }

        return Ok(result.Value);
    }

    [AllowAnonymous]
    [HttpGet("count")]
    [ProducesResponseType(typeof(ItemsCountDto), StatusCodes.Status200OK)]
    public async Task<ActionResult<ItemsCountDto>> GetItemsCount(
        [FromQuery] VehicleFilteringRequestParameters requestParameters)
    {
        var result = await Sender.Send(new CountVehiclesQueryRequest(requestParameters));

        return Ok(result.Value);
    }

    [AllowAnonymous]
    [HttpGet("price-range")]
    [ProducesResponseType(typeof(PriceRangeDto), StatusCodes.Status200OK)]
    public async Task<ActionResult<PriceRangeDto>> GetPriceRange(
        [FromQuery] VehicleFilteringRequestParameters requestParameters)
    {
        var result = await Sender.Send(new VehiclePriceRangeQueryRequest(requestParameters));

        return Ok(result.Value);
    }

    [HasAccessPermission("vehicles:create")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Guid>> CreateVehicle(CreateVehicleCommandRequest request)
    {
        var result = await Sender.Send(request);

        if (result is IValidationResult validationResult)
        {
            return BadRequest(CreateValidationProblemDetails(result.Error!, validationResult.Errors));
        }

        return CreatedAtRoute("GetVehicleById", new { id = result.Value }, result.Value);
    }

    // TODO implement safety checks for if user actually owns the vehicle he is trying to update.
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateVehicle(Guid id, [FromBody] UpdateVehicleCommandRequest request)
    {
        request = request with { Id = id };

        var result = await Sender.Send(request);

        if (result is IValidationResult validationResult)
        {
            return BadRequest(CreateValidationProblemDetails(result.Error!, validationResult.Errors));
        }

        if (!result.IsSuccess)
        {
            return NotFound(CreateNotFoundProblemDetails(result.Error!));
        }

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> DeleteVehicle(Guid id)
    {
        var result = await Sender.Send(new DeleteVehicleCommandRequest(id));

        if (!result.IsSuccess)
        {
            return NotFound(CreateNotFoundProblemDetails(result.Error!));
        }

        return NoContent();
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [HttpPost("{id:guid}/images")]
    public async Task<ActionResult> AddImageToVehicle(Guid id, List<IFormFile> images)
    {
        var request = new AddImagesToVehicleCommandRequest(id, images);

        var result = await Sender.Send(request);

        if (result is IValidationResult validationResult)
        {
            return BadRequest(CreateValidationProblemDetails(result.Error!, validationResult.Errors));
        }

        if (result.Error == Error.None)
        {
            return Ok();
        }

        return Ok(result.Error);
    }

    // [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    // [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    // [HttpDelete("images")]
    // public async Task<ActionResult> DeleteImageFromVehicle(
    //     [FromBody] RemoveImageFromVehicleCommand removeImageFromVehicleCommand)
    // {
    //     return HandleResult(await Mediator.Send(removeImageFromVehicleCommand));
    // }
    //
    // [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    // [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    // [HttpPost("images/main")]
    // public async Task<ActionResult> SetVehicleMainImage(
    //     [FromBody] SetVehicleMainImageCommand setVehicleMainImageCommand)
    // {
    //     return HandleResult(await Mediator.Send(setVehicleMainImageCommand));
    // }
}