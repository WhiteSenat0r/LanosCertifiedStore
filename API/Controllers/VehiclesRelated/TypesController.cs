using API.Controllers.Common;
using API.Responses;
using Application.Commands.Types.CreateType;
using Application.Commands.Types.DeleteType;
using Application.Commands.Types.UpdateType;
using Application.Core;
using Application.Dtos.TypeDtos;
using Application.Queries.Types;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.VehiclesRelated;

public sealed class TypesController : BaseEntityRelatedApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(Result<IReadOnlyList<TypeDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetTypes()
    {
        return HandleResult(await Mediator.Send(new ListTypesQuery()));
    }

    [HttpPost]
    [ProducesResponseType(typeof(Result<Unit>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateType([FromQuery] string name)
    {
        return HandleResult(await Mediator.Send(new CreateTypeCommand(name)));
    }

    [HttpPut]
    [ProducesResponseType(typeof(Result<Unit>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateType([FromBody] UpdateTypeDto updateTypeDto)
    {
        return HandleResult(await Mediator.Send(new UpdateTypeCommand(updateTypeDto)));
    }

    [HttpDelete("{name}")]
    [ProducesResponseType(typeof(Result<Unit>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteType(string name)
    {
        return HandleResult(await Mediator.Send(new DeleteTypeCommand(name)));
    }
}