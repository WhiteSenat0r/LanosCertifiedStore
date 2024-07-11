using API.Controllers.Common;
using Application.Shared.DtosRelated;
using Application.Shared.ResultRelated;
using Application.Shared.ValidationRelated;
using Application.VehicleModels;
using Application.VehicleModels.Commands.CreateVehicleModelRelated;
using Application.VehicleModels.Commands.UpdateVehicleModelRelated;
using Application.VehicleModels.Dtos;
using Application.VehicleModels.Queries.CollectionVehicleBrandlessModelsQueryRelated;
using Application.VehicleModels.Queries.CollectionVehicleModelsQueryRelated;
using Application.VehicleModels.Queries.CountVehicleModelsQueryRelated;
using Application.VehicleModels.Queries.SingleVehicleModelQueryRelated;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.VehicleRelated;

[Route("api/Models")]
public sealed class VehicleModelsController : BaseApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(PaginationResult<VehicleModelDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginationResult<VehicleModelDto>>> GetModels(
        [FromQuery] VehicleModelFilteringRequestParameters requestParameters)
    {
        var result = await Mediator.Send(new CollectionVehicleModelsQueryRequest(requestParameters));
        
        return Ok(result.Value);
    }
    
    [HttpGet("Brandless")]
    [ProducesResponseType(typeof(PaginationResult<VehicleModelDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginationResult<VehicleModelDto>>> GetBrandlessModels(
        [FromQuery] VehicleModelFilteringRequestParameters requestParameters)
    {
        var result = await Mediator.Send(new CollectionVehicleBrandlessModelsQueryRequest(requestParameters));
        
        return Ok(result.Value);
    }

    [HttpGet("{id:guid}", Name = "GetModelById")]
    [ProducesResponseType(typeof(SingleVehicleModelDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SingleVehicleModelDto>> GetModel(Guid id)
    {
        var result = await Mediator.Send(new SingleVehicleModelQueryRequest(id));

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
        var result = await Mediator.Send(new CountVehicleModelsQueryRequest(requestParameters));
        
        return Ok(result.Value);
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> CreateBrand([FromBody] CreateVehicleModelCommandRequest createVehicleCommandRequest)
    {
        var result = await Mediator.Send(createVehicleCommandRequest);

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
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateModel(
        [FromBody] UpdateVehicleModelCommandRequest updateVehicleModelCommandRequest)
    {
        var result = await Mediator.Send(updateVehicleModelCommandRequest);

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