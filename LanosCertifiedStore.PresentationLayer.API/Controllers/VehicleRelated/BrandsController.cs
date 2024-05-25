using API.Controllers.Common;
using API.Responses;
using Application.Commands.Brands.CreateBrand;
using Application.Commands.Brands.DeleteBrand;
using Application.Commands.Brands.UpdateBrand;
using Application.Core.Results;
using Application.Dtos.BrandDtos;
using Application.Dtos.Common;
using Application.Queries.Brands.BrandQueryRelated;
using Application.Queries.Brands.CountBrandsQueryRelated;
using Application.RequestParams;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.VehicleRelated;

public sealed class BrandsController : BaseEntityRelatedApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(PaginationResult<BrandDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginationResult<BrandDto>>> GetBrands(
        [FromQuery] VehicleBrandFilteringRequestParameters requestParameters)
    {
        return HandleResult(await Mediator.Send(new ListBrandsQuery(requestParameters)));
    }
    
    [HttpGet("countItems")]
    [ProducesResponseType(typeof(ItemsCountDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ItemsCountDto>> GetItemsCount(
        [FromQuery] VehicleBrandFilteringRequestParameters requestParameters)
    {
        return HandleResult(await Mediator.Send(new CountBrandsQuery(requestParameters)));
    }

    [HttpPost]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> CreateBrand([FromBody] CreateBrandCommand createCommand)
    {
        return HandleResult(await Mediator.Send(createCommand));
    }

    [HttpPut]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateBrand([FromBody] UpdateBrandCommand updateCommand)
    {
        return HandleResult(await Mediator.Send(updateCommand));
    }

    [HttpDelete]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> DeleteBrand([FromBody] DeleteBrandCommand deleteCommand)
    {
        return HandleResult(await Mediator.Send(deleteCommand));
    }
}