using Application.Core;
using Application.Dtos.VehicleDtos;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Vehicles.ListVehicles;

internal sealed class ListVehiclesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<ListVehiclesQuery, Result<PaginationResult<VehicleDto>>>
{
    public async Task<Result<PaginationResult<VehicleDto>>> Handle(ListVehiclesQuery request,
        CancellationToken cancellationToken)
    {
        var vehicles = await unitOfWork.RetrieveRepository<Vehicle>().GetAllEntitiesAsync(
            request.RequestParameters);

        var mappedVehicles = mapper.Map<IReadOnlyList<Vehicle>, IReadOnlyList<VehicleDto>>(vehicles);

        var vehiclesCount = await unitOfWork.RetrieveRepository<Vehicle>().CountAsync();
        
        var returnedResult = new PaginationResult<VehicleDto>(
            mappedVehicles,
            request.RequestParameters.PageIndex,
            vehiclesCount,
            await unitOfWork.RetrieveRepository<Vehicle>().CountAsync(request.RequestParameters));

        return Result<PaginationResult<VehicleDto>>.Success(returnedResult);
    }
}