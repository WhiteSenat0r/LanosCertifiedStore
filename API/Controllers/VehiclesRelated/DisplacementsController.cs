using API.Controllers.Common;
using API.Responses;
using Application.Commands.Displacements.CreateDisplacement;
using Application.Commands.Displacements.DeleteDisplacement;
using Application.Commands.Displacements.UpdateDisplacement;
using Application.Core;
using Application.Dtos.DisplacementDtos;
using Application.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.VehiclesRelated;

public sealed class DisplacementsController : BaseEntityRelatedApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(Result<IReadOnlyList<DisplacementDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetDisplacements()
    {
        return HandleResult(await Mediator.Send(new ListModelsQuery()));
    }

    [HttpPost]
    [ProducesResponseType(typeof(Result<Unit>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateDisplacement([FromQuery] double value)
    {
        return HandleResult(await Mediator.Send(new CreateDisplacementCommand(value)));
    }

    [HttpPut]
    [ProducesResponseType(typeof(Result<Unit>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateDisplacement([FromBody] UpdateDisplacementDto updateDisplacementDto)
    {
        return HandleResult(await Mediator.Send(new UpdateDisplacementCommand(updateDisplacementDto)));
    }

    [HttpDelete("{value}")]
    [ProducesResponseType(typeof(Result<Unit>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteDisplacement(double value)
    {
        return HandleResult(await Mediator.Send(new DeleteDisplacementCommand(value)));
    }
}