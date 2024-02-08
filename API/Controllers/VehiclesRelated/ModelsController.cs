using API.Controllers.Common;
using API.Responses;
using Application.Commands.Models.CreateModel;
using Application.Commands.Models.DeleteModel;
using Application.Commands.Models.UpdateModel;
using Application.Core;
using Application.Dtos.ModelDtos;
using Application.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.VehiclesRelated;

public sealed class ModelsController : BaseEntityRelatedApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(Result<IReadOnlyList<ModelDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetModels()
    {
        return HandleResult(await Mediator.Send(new ListModelsQuery()));
    }

    [HttpPost]
    [ProducesResponseType(typeof(Result<Unit>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateModel([FromQuery] Guid brandId, [FromQuery] string name)
    {
        return HandleResult(await Mediator.Send(new CreateModelCommand(brandId, name)));
    }

    [HttpPut]
    [ProducesResponseType(typeof(Result<Unit>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateModel([FromBody] UpdateModelDto updateBrandDto)
    {
        return HandleResult(await Mediator.Send(new UpdateModelCommand(updateBrandDto)));
    }

    [HttpDelete("{name}")]
    [ProducesResponseType(typeof(Result<Unit>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteModel(string name)
    {
        return HandleResult(await Mediator.Send(new DeleteModelCommand(name)));
    }
}