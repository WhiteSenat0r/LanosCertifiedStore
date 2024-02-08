using API.Controllers.Common;
using Application.Commands.Brands.CreateBrand;
using Application.Commands.Brands.DeleteBrand;
using Application.Commands.Brands.UpdateBrand;
using Application.Dtos.BrandDtos;
using Application.Queries.Brands;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.VehiclesRelated;

public sealed class BrandsController : BaseEntityRelatedApiController
{
    [HttpGet]
    public async Task<IActionResult> GetBrands()
    {
        return HandleResult(await Mediator.Send(new ListBrandsQuery()));
    }

    [HttpPost]
    public async Task<IActionResult> CreateBrand([FromQuery] string name)
    {
        return HandleResult(await Mediator.Send(new CreateBrandCommand(name)));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBrand([FromBody] UpdateBrandDto updateBrandDto)
    {
        return HandleResult(await Mediator.Send(new UpdateBrandCommand(updateBrandDto)));
    }

    [HttpDelete("{name}")]
    public async Task<IActionResult> DeleteBrand(string name)
    {
        return HandleResult(await Mediator.Send(new DeleteBrandCommand(name)));
    }
}