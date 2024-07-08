using API.Controllers.Common;
using Application.Core.Results;
using Application.Dtos.Common;
using Application.Dtos.TypeDtos;
using Application.QueryRequests.TypesRelated.VehicleDrivetrainTypeRelated.
    CollectionVehicleDrivetrainTypesQueryRequestRelated;
using Application.RequestParameters.TypeRelated;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.TypeRelated;

[Route("api/DrivetrainTypes")]
public sealed class VehicleDrivetrainTypesController : BaseApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(PaginationResult<VehicleDrivetrainTypeDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginationResult<VehicleDrivetrainTypeDto>>> GetTypes(
        [FromQuery] VehicleDrivetrainTypeFilteringRequestParameters requestParameters)
    {
        var result = await Mediator.Send(new CollectionVehicleDrivetrainTypesQueryRequest(requestParameters));

        return Ok(result.Value);
    }
}