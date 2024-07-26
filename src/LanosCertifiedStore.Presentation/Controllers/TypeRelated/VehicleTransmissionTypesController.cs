using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.VehicleTransmissionTypes;
using LanosCertifiedStore.Application.VehicleTransmissionTypes.Queries.CollectionVehicleTransmissionTypesQueryRelated;
using LanosCertifiedStore.Presentation.Controllers.Common;
using Microsoft.AspNetCore.Mvc;

namespace LanosCertifiedStore.Presentation.Controllers.TypeRelated;

[Route("api/TransmissionTypes")]
public sealed class VehicleTransmissionTypesController : BaseApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(PaginationResult<VehicleTransmissionTypeDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginationResult<VehicleTransmissionTypeDto>>> GetTypes(
        [FromQuery] string? sortingType)
    {
        var result = await Sender.Send(new CollectionVehicleTransmissionTypesQueryRequest(
            new VehicleTransmissionTypeFilteringRequestParameters
            {
                ItemQuantity = ItemQuantitySelection.TwentyFive,
                SortingType = sortingType ?? string.Empty
            }));

        return Ok(result.Value);
    }
}