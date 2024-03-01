using API.Controllers.Common;
using API.Responses;
using Application.Commands.Brands.CreateBrand;
using Application.Commands.Brands.DeleteBrand;
using Application.Commands.Brands.UpdateBrand;
using Application.Dtos.BrandDtos;
using Application.Queries.Brands.BrandDetailsQueryRelated;
using Application.Queries.Brands.BrandQueryRelated;
using Application.RequestParams;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.VehiclesRelated;

public sealed class BrandsController : BaseEntityRelatedApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<BrandDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IReadOnlyList<BrandDto>>> GetBrands(
        [FromQuery] VehicleBrandFilteringRequestParameters requestParameters)
    {
        return HandleResult(await Mediator.Send(new ListBrandsQuery(requestParameters)));
    }
    
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(IReadOnlyList<BrandDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BrandDto>> GetBrand(Guid id)
    {
        return HandleResult(await Mediator.Send(new BrandDetailsQuery(id)));
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