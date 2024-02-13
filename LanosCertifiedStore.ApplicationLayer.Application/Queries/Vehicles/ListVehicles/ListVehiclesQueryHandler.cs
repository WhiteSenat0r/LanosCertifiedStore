using Application.Core;
using Application.Dtos.VehicleDtos;
using Application.QuerySpecifications.VehiclesRelated;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Queries.Vehicles.ListVehicles;

internal sealed class ListVehiclesQueryHandler(IRepository<Vehicle> vehicleRepository, IMapper mapper)
    : IRequestHandler<ListVehiclesQuery, Result<PaginationResult<VehicleDto>>>
{
    public async Task<Result<PaginationResult<VehicleDto>>> Handle(ListVehiclesQuery request,
        CancellationToken cancellationToken)
    {
        var vehicles = await vehicleRepository.GetAllEntitiesAsync(
            new VehicleQuerySpecification(request.RequestParameters));

        var mappedVehicles = mapper.Map<IReadOnlyList<Vehicle>, IReadOnlyList<VehicleDto>>(vehicles);

        var returnedResult = new PaginationResult<VehicleDto>(
            mappedVehicles, request.RequestParameters, mappedVehicles.Count);

        return Result<PaginationResult<VehicleDto>>.Success(returnedResult);
    }
}