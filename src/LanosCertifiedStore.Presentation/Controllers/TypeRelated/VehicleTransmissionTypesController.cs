using API.Controllers.Common;
using Application.Dtos.TypeDtos;
using Application.QueryRequests.TypesRelated.VehicleTransmissionTypeRelated
    .CollectionVehicleTransmissionTypesQueryRelated;
using Application.RequestParameters.Common.Enums;
using Application.RequestParameters.TypeRelated;
using Application.Shared.ResultRelated;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.TypeRelated;

[Route("api/TransmissionTypes")]
public sealed class VehicleTransmissionTypesController : BaseApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(PaginationResult<VehicleTransmissionTypeDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginationResult<VehicleTransmissionTypeDto>>> GetTypes(
        [FromQuery] string? sortingType)
    {
        var result = await Mediator.Send(new CollectionVehicleTransmissionTypesQueryRequest(
            new VehicleTransmissionTypeFilteringRequestParameters
            {
                ItemQuantity = ItemQuantitySelection.TwentyFive,
                SortingType = sortingType ?? string.Empty
            }));

        return Ok(result.Value);
    }
}