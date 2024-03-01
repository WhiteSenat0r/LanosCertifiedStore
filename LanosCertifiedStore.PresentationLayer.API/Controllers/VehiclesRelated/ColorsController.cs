using API.Controllers.Common;
using API.Responses;
using Application.Commands.Colors.CreateColor;
using Application.Commands.Colors.DeleteColor;
using Application.Commands.Colors.UpdateColor;
using Application.Dtos.ColorDtos;
using Application.Queries.Colors;
using Application.RequestParams;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.VehiclesRelated;

public sealed class ColorsController : BaseEntityRelatedApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<ColorDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IReadOnlyList<ColorDto>>> GetColors(
        [FromQuery] VehicleColorFilteringRequestParameters requestParameters)
    {
        return HandleResult(await Mediator.Send(new ColorsQuery(requestParameters)));
    }

    [HttpPost]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> CreateColor([FromBody] CreateColorCommand createCommand)
    {
        return HandleResult(await Mediator.Send(createCommand));
    }

    [HttpPut]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateColor([FromBody] UpdateColorCommand updateCommand)
    {
        return HandleResult(await Mediator.Send(updateCommand));
    }

    [HttpDelete]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> DeleteColor([FromBody] DeleteColorCommand deleteCommand)
    {
        return HandleResult(await Mediator.Send(deleteCommand));
    }
}