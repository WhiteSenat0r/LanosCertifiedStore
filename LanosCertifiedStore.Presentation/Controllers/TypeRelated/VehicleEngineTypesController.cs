using API.Controllers.Common;
using API.Responses;
using Application.Commands.Types.VehicleEngineTypeRelated.CreateEngineType;
using Application.Commands.Types.VehicleEngineTypeRelated.DeleteEngineType;
using Application.Commands.Types.VehicleEngineTypeRelated.UpdateEngineType;
using Application.Core.Results;
using Application.Dtos.Common;
using Application.Dtos.TypeDtos;
using Application.Queries.Types.VehicleEngineTypeRelated;
using Application.Queries.Types.VehicleEngineTypeRelated.CountEngineTypesQueryRelated;
using Application.RequestParams.TypeRelated;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.TypeRelated;

public sealed class VehicleEngineTypesController : BaseEntityRelatedApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(PaginationResult<VehicleEngineTypeDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginationResult<VehicleEngineTypeDto>>> GetTypes(
        [FromQuery] VehicleEngineTypeFilteringRequestParameters requestParameters)
    {
        return HandleResult(await Mediator.Send(new VehicleEngineTypesQuery(requestParameters)));
    }
    
    [HttpGet("countItems")]
    [ProducesResponseType(typeof(ItemsCountDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ItemsCountDto>> GetItemsCount(
        [FromQuery] VehicleEngineTypeFilteringRequestParameters requestParameters)
    {
        return HandleResult(await Mediator.Send(new CountEngineTypesQuery(requestParameters)));
    }

    [HttpPost]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> CreateType([FromBody] CreateEngineTypeCommand createCommand)
    {
        return HandleResult(await Mediator.Send(createCommand));
    }

    [HttpPut]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateType([FromBody] UpdateEngineTypeCommand updateCommand)
    {
        return HandleResult(await Mediator.Send(updateCommand));
    }

    [HttpDelete]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> DeleteType([FromBody] DeleteEngineTypeCommand deleteCommand)
    {
        return HandleResult(await Mediator.Send(deleteCommand));
    }
}