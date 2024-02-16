using System.ComponentModel.DataAnnotations;
using API.Controllers.Common;
using API.Responses;
using Application.Commands.Displacements.CreateDisplacement;
using Application.Commands.Displacements.DeleteDisplacement;
using Application.Commands.Displacements.UpdateDisplacement;
using Application.Dtos.DisplacementDtos;
using Application.Queries.Displacements;
using Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.VehiclesRelated;

public sealed class DisplacementsController : BaseEntityRelatedApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<DisplacementDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IReadOnlyList<DisplacementDto>>> GetDisplacements()
    {
        return HandleResult(await Mediator.Send(new ListDisplacementsQuery()));
    }

    [HttpPost]
    [ProducesResponseType(typeof(Result<Unit>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ValidationResult), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> CreateDisplacement([FromQuery] double value)
    {
        return HandleResult(await Mediator.Send(new CreateDisplacementCommand(value)));
    }

    [HttpPut]
    [ProducesResponseType(typeof(Result<Unit>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ValidationResult), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateDisplacement([FromBody] UpdateDisplacementDto updateDisplacementDto)
    {
        return HandleResult(await Mediator.Send(new UpdateDisplacementCommand(updateDisplacementDto)));
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(Result<Unit>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ValidationResult), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> DeleteDisplacement(Guid id)
    {
        return HandleResult(await Mediator.Send(new DeleteDisplacementCommand(id)));
    }
}