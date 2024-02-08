using API.Controllers.Common;
using Application.Commands.Types.CreateType;
using Application.Commands.Types.DeleteType;
using Application.Commands.Types.UpdateType;
using Application.Dtos.TypeDtos;
using Application.Queries.Types;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.VehiclesRelated;

public sealed class TypesController : BaseEntityRelatedApiController
{
    [HttpGet]
    public async Task<IActionResult> GetTypes()
    {
        return HandleResult(await Mediator.Send(new ListTypesQuery()));
    }

    [HttpPost]
    public async Task<IActionResult> CreateType([FromQuery] string name)
    {
        return HandleResult(await Mediator.Send(new CreateTypeCommand(name)));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateType([FromBody] UpdateTypeDto updateTypeDto)
    {
        return HandleResult(await Mediator.Send(new UpdateTypeCommand(updateTypeDto)));
    }

    [HttpDelete("{name}")]
    public async Task<IActionResult> DeleteType(string name)
    {
        return HandleResult(await Mediator.Send(new DeleteTypeCommand(name)));
    }
}