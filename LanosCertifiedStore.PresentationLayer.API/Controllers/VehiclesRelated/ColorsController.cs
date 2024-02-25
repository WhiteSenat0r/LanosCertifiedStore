using API.Controllers.Common;
using API.Responses;
using Application.Commands.Colors.CreateColor;
using Application.Commands.Colors.DeleteColor;
using Application.Commands.Colors.UpdateColor;
using Application.Dtos.ColorDtos;
using Application.Queries.Colors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.VehiclesRelated;

public sealed class ColorsController : BaseEntityRelatedApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<ColorDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IReadOnlyList<ColorDto>>> GetColors()
    {
        return HandleResult(await Mediator.Send(new ListColorsQuery()));
    }

    [HttpPost]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> CreateColor([FromBody] CreateColorDto createColorDto)
    {
        return HandleResult(await Mediator.Send(new CreateColorCommand(createColorDto)));
    }

    [HttpPut]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> UpdateColor([FromBody] UpdateColorDto updateColorDto)
    {
        return HandleResult(await Mediator.Send(new UpdateColorCommand(updateColorDto)));
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> DeleteColor(Guid id)
    {
        return HandleResult(await Mediator.Send(new DeleteColorCommand(id)));
    }
}