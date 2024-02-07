using API.Controllers.Common;
using Application.Commands.Models.CreateModel;
using Application.Commands.Models.DeleteModel;
using Application.Commands.Models.UpdateModel;
using Application.Dtos.ModelDtos;
using Application.Queries.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.VehiclesRelated;

public sealed class ModelsController : BaseEntityRelatedApiController
{
    [HttpGet("GetAllModels")]
    public async Task<IActionResult> GetBrands()
    {
        return HandleResult(await Mediator.Send(new ListModelsQuery()));
    }

    [HttpPost("CreateModel/{name}")]
    public async Task<IActionResult> CreateBrand(string name)
    {
        return HandleResult(await Mediator.Send(new CreateModelCommand(name)));
    }

    [HttpPut("UpdateModel")]
    public async Task<IActionResult> UpdateBrand([FromBody] UpdateModelDto updateBrandDto)
    {
        return HandleResult(await Mediator.Send(new UpdateModelCommand(updateBrandDto)));
    }

    [HttpDelete("DeleteModel/{name}")]
    public async Task<IActionResult> DeleteBrand(string name)
    {
        return HandleResult(await Mediator.Send(new DeleteModelCommand(name)));
    }
}