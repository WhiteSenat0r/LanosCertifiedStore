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
    public async Task<IActionResult> CreateColor(string colorName)
    {
        return HandleResult(await Mediator.Send(new CreateColorCommand(colorName)));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateColor(UpdateColorDto updateColorDto)
    {
        return HandleResult(await Mediator.Send(new UpdateColorCommand(updateColorDto)));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteColor(string colorName)
    {
        return HandleResult(await Mediator.Send(new DeleteColorCommand(colorName)));
    }
}