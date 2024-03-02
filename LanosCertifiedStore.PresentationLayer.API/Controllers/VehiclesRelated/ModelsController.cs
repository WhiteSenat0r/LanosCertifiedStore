using API.Controllers.Common;
using API.Responses;
using Application.Commands.Models.CreateModel;
using Application.Commands.Models.DeleteModel;
using Application.Commands.Models.UpdateModel;
using Application.Dtos.ModelDtos;
using Application.Queries.Models.ModelDetailsQueryRelated;
using Application.Queries.Models.ModelQueryRelated;
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
        return HandleResult(await Mediator.Send(new ModelsQuery(requestParameters)));
    }
    
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ModelDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> GetModel(Guid id)
    {
        return HandleResult(await Mediator.Send(new SingleModelQuery(id)));
    }

    [HttpPost]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> CreateModel([FromBody] CreateModelCommand createCommand)
    {
        return HandleResult(await Mediator.Send(createCommand));
    }

    [HttpPut]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateModel([FromBody] UpdateModelCommand updateCommand)
    {
        return HandleResult(await Mediator.Send(updateCommand));
    }

    [HttpDelete]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> DeleteModel([FromBody] DeleteModelCommand deleteCommand)
    {
        return HandleResult(await Mediator.Send(deleteCommand));
    }
}