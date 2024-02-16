using Application.Dtos.VehicleDtos;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Vehicles.VehicleDetails;

internal sealed class VehicleDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<VehicleDetailsQuery, Result<VehicleDto>>
{
    public async Task<Result<VehicleDto>> Handle(VehicleDetailsQuery request, CancellationToken cancellationToken)
    {
        var vehicle = await unitOfWork.RetrieveRepository<Vehicle>().GetEntityByIdAsync(request.Id);

        if (vehicle is null) return null!;
        
        var vehicleToReturn = mapper.Map<Vehicle, VehicleDto>(vehicle);

        return Result<VehicleDto>.Success(vehicleToReturn);
    }
}