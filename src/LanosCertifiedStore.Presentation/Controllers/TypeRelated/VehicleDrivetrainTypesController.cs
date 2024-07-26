using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.VehicleDrivetrainTypes;
using LanosCertifiedStore.Application.VehicleDrivetrainTypes.Queries.CollectionVehicleDrivetrainTypesQueryRequestRelated;
using LanosCertifiedStore.Presentation.Controllers.Common;
using Microsoft.AspNetCore.Mvc;

namespace LanosCertifiedStore.Presentation.Controllers.TypeRelated;

[Route("api/DrivetrainTypes")]
public sealed class VehicleDrivetrainTypesController : BaseApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(PaginationResult<VehicleDrivetrainTypeDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginationResult<VehicleDrivetrainTypeDto>>> GetTypes(
        [FromQuery] string? sortingType)
    {
        var result = await Sender.Send(new CollectionVehicleDrivetrainTypesQueryRequest(
            new VehicleDrivetrainTypeFilteringRequestParameters
            {
                ItemQuantity = ItemQuantitySelection.TwentyFive,
                SortingType = sortingType ?? string.Empty
            }));

        return Ok(result.Value);
    }
}