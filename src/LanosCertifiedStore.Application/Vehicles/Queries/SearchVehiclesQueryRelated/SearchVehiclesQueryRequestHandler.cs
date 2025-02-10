using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using MediatR;

namespace LanosCertifiedStore.Application.Vehicles.Queries.SearchVehiclesQueryRelated;

internal sealed class SearchVehiclesQueryRequestHandler(IVehicleService vehicleService) :
    IRequestHandler<SearchVehiclesQueryRequest, Result<PaginationResult<SearchVehicleDto>>>
{
    public async Task<Result<PaginationResult<SearchVehicleDto>>> Handle(
        SearchVehiclesQueryRequest request,
        CancellationToken cancellationToken)
    {
        var vehicles = await vehicleService.FindRelevantVehicles(request, cancellationToken);
        
        var paginationResult = new PaginationResult<SearchVehicleDto>(vehicles, request.FilteringParameters.PageIndex);
        
        return paginationResult;
    }
}