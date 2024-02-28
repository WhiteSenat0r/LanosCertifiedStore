using API.Controllers.Common;
using API.Responses;
using Application.Commands.Models.CreateModel;
using Application.Commands.Models.DeleteModel;
using Application.Commands.Models.UpdateModel;
using Application.Dtos.ModelDtos;
using Application.Queries.Models;
using Application.RequestParams;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.VehiclesRelated;

public sealed class ModelsController : BaseEntityRelatedApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<ModelDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IReadOnlyList<ModelDto>>> GetModels(
        [FromQuery] VehicleModelFilteringRequestParameters requestParameters)
    {
        return HandleResult(await Mediator.Send(new ListModelsQuery(requestParameters)));
    }

    [HttpPost]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> CreateModel([FromBody] CreateModelCommand createModelCommand)
    {
        return HandleResult(await Mediator.Send(createModelCommand));
    }

    [HttpPut]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateModel([FromBody] UpdateModelDto updateBrandDto)
    {
        return HandleResult(await Mediator.Send(new UpdateModelCommand(updateBrandDto)));
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> DeleteModel(Guid id)
    {
        return HandleResult(await Mediator.Send(new DeleteModelCommand(id)));
    }
}