using Application.Dtos.VehicleDtos;
using Application.Queries.Common.DetailsQueryRelated;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Vehicles.VehicleDetailsQueryRelated;

internal sealed class VehicleDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    DetailsQueryHandlerBase<Vehicle, SingleVehicleDto>(unitOfWork, mapper),
    IRequestHandler<VehicleDetailsQuery, Result<SingleVehicleDto>>
{
    public Task<Result<SingleVehicleDto>> Handle(VehicleDetailsQuery request, CancellationToken cancellationToken) => 
        base.Handle(request, cancellationToken);
}