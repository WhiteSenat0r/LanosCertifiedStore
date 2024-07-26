using LanosCertifiedStore.Application.Shared.DtosRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.Shared.ValidationRelated;
using LanosCertifiedStore.Application.VehicleBrands;
using LanosCertifiedStore.Application.VehicleBrands.Commands.CreateVehicleBrandRelated;
using LanosCertifiedStore.Application.VehicleBrands.Commands.UpdateVehicleBrandRelated;
using LanosCertifiedStore.Application.VehicleBrands.Dtos;
using LanosCertifiedStore.Application.VehicleBrands.Queries.CollectionVehicleBrandsQueryRelated;
using LanosCertifiedStore.Application.VehicleBrands.Queries.CountVehicleBrandsQueryRelated;
using LanosCertifiedStore.Application.VehicleBrands.Queries.SingleVehicleBrandQueryRelated;
using LanosCertifiedStore.Presentation.Controllers.Common;
using Microsoft.AspNetCore.Mvc;

namespace LanosCertifiedStore.Presentation.Controllers.VehicleRelated;

[Route("api/Brands")]
public sealed class VehicleBrandsController : BaseApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(PaginationResult<VehicleBrandDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginationResult<VehicleBrandDto>>> GetBrands(
        [FromQuery] VehicleBrandFilteringRequestParameters requestParameters)
    {
        var result = await Sender.Send(new CollectionVehicleBrandsQueryRequest(requestParameters));
        
        return Ok(result.Value);
    }

    [HttpGet("{id:guid}", Name = "GetBrandById")]
    [ProducesResponseType(typeof(SingleVehicleBrandDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SingleVehicleBrandDto>> GetBrand(Guid id)
    {
        var result = await Sender.Send(new SingleVehicleBrandQueryRequest(id));

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
        var result = await Sender.Send(new CountVehicleBrandsQueryRequest(requestParameters));
        
        return Ok(result.Value);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> CreateBrand([FromBody] CreateVehicleBrandCommandRequest createVehicleCommandRequest)
    {
        var result = await Sender.Send(createVehicleCommandRequest);

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
        var result = await Sender.Send(updateVehicleBrandCommandRequest);

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