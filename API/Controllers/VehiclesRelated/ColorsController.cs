using API.Controllers.Common;
using Application.Commands.Colors.CreateColor;
using Application.Commands.Colors.DeleteColor;
using Application.Commands.Colors.UpdateColor;
using Application.Dtos.ColorDtos;
using Application.Queries.Colors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.VehiclesRelated;

public sealed class ColorsController : BaseEntityRelatedApiController
{
    [HttpGet]
    public async Task<IActionResult> GetColors()
    {
        return HandleResult(await Mediator.Send(new ListColorsQuery()));
    }

    [HttpPost]
    public async Task<IActionResult> CreateColor([FromQuery] string name)
    {
        return HandleResult(await Mediator.Send(new CreateColorCommand(name)));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateColor([FromBody] UpdateColorDto updateColorDto)
    {
        return HandleResult(await Mediator.Send(new UpdateColorCommand(updateColorDto)));
    }

    [HttpDelete("{name}")]
    public async Task<IActionResult> DeleteColor(string name)
    {
        return HandleResult(await Mediator.Send(new DeleteColorCommand(name)));
    }
}