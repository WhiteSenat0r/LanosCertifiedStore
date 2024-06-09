using API.Controllers.Common;
using API.Responses;
using Application.Commands.Types.VehicleBodyTypeRelated.CreateBodyType;
using Application.Commands.Types.VehicleBodyTypeRelated.DeleteBodyType;
using Application.Commands.Types.VehicleBodyTypeRelated.UpdateBodyType;
using Application.Core.Results;
using Application.Dtos.Common;
using Application.Dtos.TypeDtos;
using Application.Queries.Types.VehicleBodyTypeRelated;
using Application.Queries.Types.VehicleBodyTypeRelated.CountBodyTypesQueryRelated;
using Application.RequestParams.TypeRelated;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.TypeRelated;

public sealed class VehicleBodyTypesController : BaseEntityRelatedApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(PaginationResult<VehicleBodyTypeDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginationResult<VehicleBodyTypeDto>>> GetTypes(
        [FromQuery] VehicleBodyTypeFilteringRequestParameters requestParameters)
    {
        return HandleResult(await Mediator.Send(new VehicleBodyTypesQuery(requestParameters)));
    }
    
    [HttpGet("countItems")]
    [ProducesResponseType(typeof(ItemsCountDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ItemsCountDto>> GetItemsCount(
        [FromQuery] VehicleBodyTypeFilteringRequestParameters requestParameters)
    {
        return HandleResult(await Mediator.Send(new CountBodyTypesQuery(requestParameters)));
    }

    [HttpPost]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> CreateType([FromBody] CreateBodyTypeCommand createCommand)
    {
        return HandleResult(await Mediator.Send(createCommand));
    }

    [HttpPut]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateType([FromBody] UpdateBodyTypeCommand updateCommand)
    {
        return HandleResult(await Mediator.Send(updateCommand));
    }

    [HttpDelete]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> DeleteType([FromBody] DeleteBodyTypeCommand deleteCommand)
    {
        return HandleResult(await Mediator.Send(deleteCommand));
    }
}