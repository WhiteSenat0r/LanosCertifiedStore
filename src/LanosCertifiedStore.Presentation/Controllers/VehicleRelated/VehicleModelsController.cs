using LanosCertifiedStore.Application.Shared.DtosRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.Shared.ValidationRelated;
using LanosCertifiedStore.Application.VehicleModels;
using LanosCertifiedStore.Application.VehicleModels.Commands.CreateVehicleModelRelated;
using LanosCertifiedStore.Application.VehicleModels.Commands.UpdateVehicleModelRelated;
using LanosCertifiedStore.Application.VehicleModels.Dtos;
using LanosCertifiedStore.Application.VehicleModels.Queries.CollectionVehicleBrandlessModelsQueryRelated;
using LanosCertifiedStore.Application.VehicleModels.Queries.CollectionVehicleModelsQueryRelated;
using LanosCertifiedStore.Application.VehicleModels.Queries.CountVehicleModelsQueryRelated;
using LanosCertifiedStore.Application.VehicleModels.Queries.SingleVehicleModelQueryRelated;
using LanosCertifiedStore.Infrastructure.Services.Authorization;
using LanosCertifiedStore.Presentation.Controllers.Common;
using Microsoft.AspNetCore.Mvc;

namespace LanosCertifiedStore.Presentation.Controllers.VehicleRelated;

[Route("api/Models")]
public sealed class VehicleModelsController : BaseApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(PaginationResult<VehicleModelDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginationResult<VehicleModelDto>>> GetModels(
        [FromQuery] VehicleModelFilteringRequestParameters requestParameters)
    {
        var result = await Sender.Send(new CollectionVehicleModelsQueryRequest(requestParameters));

        return Ok(result.Value);
    }

    [HttpGet("Brandless")]
    [ProducesResponseType(typeof(PaginationResult<VehicleModelDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginationResult<VehicleModelDto>>> GetBrandlessModels(
        [FromQuery] VehicleModelFilteringRequestParameters requestParameters)
    {
        var result = await Sender.Send(new CollectionBrandlessVehicleModelsQueryRequest(requestParameters));

        return Ok(result.Value);
    }

    [HttpGet("{id:guid}", Name = "GetModelById")]
    [ProducesResponseType(typeof(SingleVehicleModelDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SingleVehicleModelDto>> GetModel(Guid id)
    {
        var result = await Sender.Send(new SingleVehicleModelQueryRequest(id));

        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }

        return NotFound(CreateNotFoundProblemDetails(result.Error!));
    }

    [HttpGet("CountItems")]
    [ProducesResponseType(typeof(ItemsCountDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ItemsCountDto>> GetModelsCount(
        [FromQuery] VehicleModelFilteringRequestParameters requestParameters)
    {
        var result = await Sender.Send(new CountVehicleModelsQueryRequest(requestParameters));

        return Ok(result.Value);
    }

    [HttpPost]
    [HasAccessPermission("models:create")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> CreateBrand([FromBody] CreateVehicleModelCommandRequest createVehicleCommandRequest)
    {
        var result = await Sender.Send(createVehicleCommandRequest);

        if (result is IValidationResult validationResult)
        {
            return BadRequest(CreateValidationProblemDetails(result.Error!, validationResult.Errors));
        }

        if (!result.IsSuccess)
        {
            return NotFound(CreateNotFoundProblemDetails(result.Error!));
        }

        return CreatedAtRoute("GetBrandById", new { id = result.Value }, result.Value);
    }

    [HttpPut]
    [HasAccessPermission("models:update")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateModel(
        [FromBody] UpdateVehicleModelCommandRequest updateVehicleModelCommandRequest)
    {
        var result = await Sender.Send(updateVehicleModelCommandRequest);

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
}