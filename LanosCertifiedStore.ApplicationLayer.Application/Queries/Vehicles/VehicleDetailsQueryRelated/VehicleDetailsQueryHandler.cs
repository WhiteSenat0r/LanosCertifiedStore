using Application.Dtos.VehicleDtos;
using Application.Queries.Common.DetailsQueryRelated;
using AutoMapper;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Vehicles.VehicleDetailsQueryRelated;

internal sealed class VehicleDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    DetailsQueryHandlerBase<Vehicle, VehicleDto>(unitOfWork, mapper),
    IRequestHandler<VehicleDetailsQuery, Result<VehicleDto>>
{
    public Task<Result<VehicleDto>> Handle(VehicleDetailsQuery request, CancellationToken cancellationToken) => 
        base.Handle(request, cancellationToken);
}