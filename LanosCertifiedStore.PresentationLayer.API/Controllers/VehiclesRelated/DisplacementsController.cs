﻿using API.Controllers.Common;
using API.Responses;
using Application.Commands.Displacements.CreateDisplacement;
using Application.Commands.Displacements.DeleteDisplacement;
using Application.Commands.Displacements.UpdateDisplacement;
using Application.Core;
using Application.Dtos.DisplacementDtos;
using Application.Queries.Displacements;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.VehiclesRelated;

public sealed class DisplacementsController : BaseEntityRelatedApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(Result<IReadOnlyList<DisplacementDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetDisplacements()
    {
        return HandleResult(await Mediator.Send(new ListDisplacementsQuery()));
    }

    [HttpPost]
    [ProducesResponseType(typeof(Result<Unit>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateDisplacement([FromQuery] double value)
    {
        return HandleResult(await Mediator.Send(new CreateDisplacementCommand(value)));
    }

    [HttpPut]
    [ProducesResponseType(typeof(Result<Unit>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateDisplacement([FromBody] UpdateDisplacementDto updateDisplacementDto)
    {
        return HandleResult(await Mediator.Send(new UpdateDisplacementCommand(updateDisplacementDto)));
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(Result<Unit>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteDisplacement(Guid id)
    {
        return HandleResult(await Mediator.Send(new DeleteDisplacementCommand(id)));
    }
}