using Application.Dtos.Common;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Vehicles.CountVehiclesQueryRelated;

internal sealed class CountVehiclesQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CountVehiclesQuery, Result<ItemsCountDto>>
{
    public async Task<Result<ItemsCountDto>> Handle(CountVehiclesQuery request, CancellationToken cancellationToken)
    {
        var totalItemsCount = await unitOfWork.RetrieveRepository<Vehicle>().CountAsync();
        var filteredItemsCount = await unitOfWork.RetrieveRepository<Vehicle>().CountAsync(request.RequestParameters);

        var itemsCountDto = new ItemsCountDto(totalItemsCount, filteredItemsCount);
        
        return Result<ItemsCountDto>.Success(itemsCountDto);
    }
}