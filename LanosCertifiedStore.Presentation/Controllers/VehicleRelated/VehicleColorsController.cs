﻿using API.Controllers.Common;
using Application.Core.Results;
using Application.Dtos.ColorDtos;
using Application.Dtos.Common;
using Application.QueryRequests.VehicleColorsRelated.CollectionVehicleColorsQueryRequestRelated;
using Application.QueryRequests.VehicleColorsRelated.CountVehicleColorsQueryRequestRelated;
using Application.RequestParameters;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.VehicleRelated;

[Route("api/Colors")]
public sealed class VehicleColorsController : BaseApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(PaginationResult<VehicleColorDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginationResult<VehicleColorDto>>> GetColors(
        [FromQuery] VehicleColorFilteringRequestParameters requestParameters)
    {
        var result = await Mediator.Send(new CollectionVehicleColorsQueryRequest(requestParameters));
        return Ok(result.Value);
    }

    [HttpGet("CountItems")]
    [ProducesResponseType(typeof(ItemsCountDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ItemsCountDto>> GetItemsCount(
        [FromQuery] VehicleColorFilteringRequestParameters requestParameters)
    {
        var result = await Mediator.Send(new CountVehicleColorsQueryRequest(requestParameters));

        return Ok(result.Value);
    }
}