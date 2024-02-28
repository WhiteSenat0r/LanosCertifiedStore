using API.Controllers.Common;
using API.Responses;
using Application.Commands.Brands.CreateBrand;
using Application.Commands.Brands.DeleteBrand;
using Application.Commands.Brands.UpdateBrand;
using Application.Dtos.BrandDtos;
using Application.Queries.Brands.ListQueryRelated;
using Application.Queries.Brands.SingleQueryRelated;
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
    public async Task<ActionResult<BrandDto>> GetBrands(Guid id)
    {
        return HandleResult(await Mediator.Send(new SingleBrandQuery(id)));
    }

    [HttpPost]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> CreateBrand([FromQuery] string name)
    {
        return HandleResult(await Mediator.Send(new CreateBrandCommand(name)));
    }

    [HttpPut]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateBrand([FromBody] UpdateBrandDto updateBrandDto)
    {
        return HandleResult(await Mediator.Send(new UpdateBrandCommand(updateBrandDto)));
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> DeleteBrand(Guid id)
    {
        return HandleResult(await Mediator.Send(new DeleteBrandCommand(id)));
    }
}