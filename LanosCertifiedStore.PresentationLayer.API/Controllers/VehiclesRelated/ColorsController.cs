using API.Controllers.Common;
using API.Responses;
using Application.Commands.Colors.CreateColor;
using Application.Commands.Colors.DeleteColor;
using Application.Commands.Colors.UpdateColor;
using Application.Core;
using Application.Dtos.ColorDtos;
using Application.Queries.Colors;
using Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.VehiclesRelated;

public sealed class ColorsController : BaseEntityRelatedApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(Result<IReadOnlyList<ColorDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetColors()
    {
        return HandleResult(await Mediator.Send(new ListColorsQuery()));
    }

    [HttpPost]
    [ProducesResponseType(typeof(Result<Unit>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateColor([FromQuery] string name)
    {
        return HandleResult(await Mediator.Send(new CreateColorCommand(name)));
    }

    [HttpPut]
    [ProducesResponseType(typeof(Result<Unit>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateColor([FromBody] UpdateColorDto updateColorDto)
    {
        return HandleResult(await Mediator.Send(new UpdateColorCommand(updateColorDto)));
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(Result<Unit>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteColor(Guid id)
    {
        return HandleResult(await Mediator.Send(new DeleteColorCommand(id)));
    }
}