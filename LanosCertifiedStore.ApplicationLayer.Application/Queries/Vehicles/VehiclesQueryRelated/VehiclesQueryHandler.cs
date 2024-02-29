using Application.Core.Results;
using Application.Dtos.VehicleDtos;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Vehicles.VehiclesQueryRelated;

internal sealed class VehiclesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<VehiclesQuery, Result<PaginationResult<VehicleDto>>>
{
    public async Task<Result<PaginationResult<VehicleDto>>> Handle(VehiclesQuery request,
        CancellationToken cancellationToken)
    {
        var vehicles = await unitOfWork.RetrieveRepository<Vehicle>().GetAllEntitiesAsync(
            request.RequestParameters);

        var totalItemsCount = await unitOfWork.RetrieveRepository<Vehicle>().CountAsync();
        var totalFilteredItemsCount =
            await unitOfWork.RetrieveRepository<Vehicle>().CountAsync(request.RequestParameters);

        var mappedVehicles = mapper.Map<IReadOnlyList<Vehicle>, IReadOnlyList<VehicleDto>>(vehicles);

        var returnedResult = new PaginationResult<VehicleDto>(
            items: mappedVehicles,
            pageIndex: request.RequestParameters.PageIndex,
            totalItemsCount,
            totalFilteredItemsCount);

        return Result<PaginationResult<VehicleDto>>.Success(returnedResult);
    }
}