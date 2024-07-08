using API.Controllers.Common;
using Application.Dtos.TypeDtos;
using Application.QueryRequests.TypesRelated.VehicleDrivetrainTypeRelated.
    CollectionVehicleDrivetrainTypesQueryRequestRelated;
using Application.RequestParameters.Common.Enums;
using Application.RequestParameters.TypeRelated;
using Application.Shared.ResultRelated;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.TypeRelated;

[Route("api/DrivetrainTypes")]
public sealed class VehicleDrivetrainTypesController : BaseApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(PaginationResult<VehicleDrivetrainTypeDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginationResult<VehicleDrivetrainTypeDto>>> GetTypes(
        [FromQuery] string? sortingType)
    {
        var result = await Mediator.Send(new CollectionVehicleDrivetrainTypesQueryRequest(
            new VehicleDrivetrainTypeFilteringRequestParameters
            {
                ItemQuantity = ItemQuantitySelection.TwentyFive,
                SortingType = sortingType ?? string.Empty
            }));

        return Ok(result.Value);
    }
}