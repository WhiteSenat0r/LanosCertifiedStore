using API.Controllers.Common;
using Application.CommandRequests.VehicleBrandsRelated.CreateVehicleBrandRelated;
using Application.CommandRequests.VehicleBrandsRelated.UpdateBrand;
using Application.Contracts.ValidationRelated;
using Application.Core.Results;
using Application.Dtos.BrandDtos;
using Application.Dtos.Common;
using Application.QueryRequests.VehicleBrandsRelated.CollectionVehicleBrandsQueryRelated;
using Application.QueryRequests.VehicleBrandsRelated.CountVehicleBrandsQueryRelated;
using Application.QueryRequests.VehicleBrandsRelated.SingleVehicleBrandQueryRelated;
using Application.RequestParameters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.VehicleRelated;

public sealed class BrandsController : BaseModelRelatedApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(PaginationResult<VehicleBrandDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PaginationResult<VehicleBrandDto>>> GetBrands(
        [FromQuery] VehicleBrandFilteringRequestParameters requestParameters)
    {
        return Ok(await Mediator.Send(new CollectionVehicleBrandsQueryRequest(requestParameters)));
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

    [HttpGet("countItems")]
    [ProducesResponseType(typeof(ItemsCountDto), StatusCodes.Status200OK)]
    public async Task<ActionResult<ItemsCountDto>> GetBrandsCount(
        [FromQuery] VehicleBrandFilteringRequestParameters requestParameters)
    {
        return Ok(await Mediator.Send(new CountVehicleBrandsQueryRequest(requestParameters)));
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
    public async Task<ActionResult> UpdateBrand([FromBody] UpdateVehicleBrandCommandRequest updateVehicleCommandRequest)
    {
        var result = await Mediator.Send(updateVehicleCommandRequest);

        if (result is IValidationResult validationResult)
        {
            return BadRequest(CreateValidationProblemDetails(result.Error!, validationResult.Errors));
        }

        if (!result.IsSuccess)
        {
            return NotFound(result.Error);
        }

        return NoContent();
    }
}