using Application.Core;
using Application.Dtos.VehicleDtos;
using Application.QuerySpecifications.VehiclesRelated;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Queries.Vehicles.ListVehicles;

internal sealed class ListVehiclesQueryHandler(IRepository<Vehicle> vehicleRepository, IMapper mapper)
    : IRequestHandler<ListVehiclesQuery, Result<IReadOnlyList<VehicleDto>>>
{
    public async Task<Result<IReadOnlyList<VehicleDto>>> Handle(ListVehiclesQuery request,
        CancellationToken cancellationToken)
    {
        var vehicles = await vehicleRepository.GetAllEntitiesAsync(new VehicleQuerySpecification());

        var vehiclesToReturn = mapper.Map<IReadOnlyList<Vehicle>, IReadOnlyList<VehicleDto>>(vehicles);

        return Result<IReadOnlyList<VehicleDto>>.Success(vehiclesToReturn);
    }
}