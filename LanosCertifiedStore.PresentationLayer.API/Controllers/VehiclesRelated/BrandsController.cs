using API.Controllers.Common;
using API.Responses;
using Application.Commands.Brands.CreateBrand;
using Application.Commands.Brands.DeleteBrand;
using Application.Commands.Brands.UpdateBrand;
using Application.Core;
using Application.Dtos.BrandDtos;
using Application.Queries.Brands;
using Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.VehiclesRelated;

public sealed class BrandsController : BaseEntityRelatedApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(Result<IReadOnlyList<BrandDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetBrands()
    {
        return HandleResult(await Mediator.Send(new ListBrandsQuery()));
    }

    [HttpPost]
    [ProducesResponseType(typeof(Result<Unit>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateBrand([FromQuery] string name)
    {
        return HandleResult(await Mediator.Send(new CreateBrandCommand(name)));
    }

    [HttpPut]
    [ProducesResponseType(typeof(Result<Unit>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateBrand([FromBody] UpdateBrandDto updateBrandDto)
    {
        return HandleResult(await Mediator.Send(new UpdateBrandCommand(updateBrandDto)));
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(Result<Unit>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteBrand(Guid id)
    {
        return HandleResult(await Mediator.Send(new DeleteBrandCommand(id)));
    }
}