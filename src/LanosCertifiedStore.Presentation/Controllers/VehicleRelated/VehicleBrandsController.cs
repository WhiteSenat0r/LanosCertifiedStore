using API.Controllers.Common;
using Application.Shared.DtosRelated;
using Application.Shared.ResultRelated;
using Application.Shared.ValidationRelated;
using Application.VehicleBrands;
using Application.VehicleBrands.Commands.CreateVehicleBrandRelated;
using Application.VehicleBrands.Commands.UpdateVehicleBrandRelated;
using Application.VehicleBrands.Dtos;
using Application.VehicleBrands.Queries.CollectionVehicleBrandsQueryRelated;
using Application.VehicleBrands.Queries.CountVehicleBrandsQueryRelated;
using Application.VehicleBrands.Queries.SingleVehicleBrandQueryRelated;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.VehicleRelated;

[Route("api/Brands")]
public sealed class VehicleBrandsController : BaseApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(PaginationResult<VehicleBrandDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginationResult<VehicleBrandDto>>> GetBrands(
        [FromQuery] VehicleBrandFilteringRequestParameters requestParameters)
    {
        var result = await Mediator.Send(new CollectionVehicleBrandsQueryRequest(requestParameters));
        
        return Ok(result.Value);
    }

    [HttpGet("{id:guid}", Name = "GetBrandById")]
    [ProducesResponseType(typeof(SingleVehicleBrandDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SingleVehicleBrandDto>> GetBrand(Guid id)
    {
        var result = await Mediator.Send(new SingleVehicleBrandQueryRequest(id));

        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }

        return NotFound(CreateNotFoundProblemDetails(result.Error!));
    }

    [HttpGet("CountItems")]
    [ProducesResponseType(typeof(ItemsCountDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ItemsCountDto>> GetBrandsCount(
        [FromQuery] VehicleBrandFilteringRequestParameters requestParameters)
    {
        var result = await Mediator.Send(new CountVehicleBrandsQueryRequest(requestParameters));
        
        return Ok(result.Value);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> CreateBrand([FromBody] CreateVehicleBrandCommandRequest createVehicleCommandRequest)
    {
        var result = await Mediator.Send(createVehicleCommandRequest);

        if (result is IValidationResult validationResult)
        {
            return BadRequest(CreateValidationProblemDetails(result.Error!, validationResult.Errors));
        }

        return CreatedAtRoute("GetBrandById", new { id = result.Value }, result.Value);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateBrand(
        [FromBody] UpdateVehicleBrandCommandRequest updateVehicleBrandCommandRequest)
    {
        var result = await Mediator.Send(updateVehicleBrandCommandRequest);

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