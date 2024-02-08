using API.Controllers.Common;
using Application.Commands.Displacements.CreateDisplacement;
using Application.Commands.Displacements.DeleteDisplacement;
using Application.Commands.Displacements.UpdateDisplacement;
using Application.Dtos.DisplacementDtos;
using Application.Queries.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.VehiclesRelated;

public sealed class DisplacementsController : BaseEntityRelatedApiController
{
    [HttpGet]
    public async Task<IActionResult> GetDisplacements()
    {
        return HandleResult(await Mediator.Send(new ListModelsQuery()));
    }

    [HttpPost]
    public async Task<IActionResult> CreateDisplacement([FromQuery] double value)
    {
        return HandleResult(await Mediator.Send(new CreateDisplacementCommand(value)));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateDisplacement([FromBody] UpdateDisplacementDto updateDisplacementDto)
    {
        return HandleResult(await Mediator.Send(new UpdateDisplacementCommand(updateDisplacementDto)));
    }

    [HttpDelete("{value}")]
    public async Task<IActionResult> DeleteDisplacement(double value)
    {
        return HandleResult(await Mediator.Send(new DeleteDisplacementCommand(value)));
    }
}