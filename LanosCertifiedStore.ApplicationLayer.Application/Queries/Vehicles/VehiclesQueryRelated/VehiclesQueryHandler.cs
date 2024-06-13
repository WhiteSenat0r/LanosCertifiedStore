using Application.Contracts.RepositoryRelated.Common;
using Application.Core.Results;
using Application.Dtos.VehicleDtos;
using Application.Queries.Common.QueryRelated;
using Application.RequestParams;
using Application.Shared;
using AutoMapper;
using Domain.Models.VehicleRelated.Classes;
using MediatR;

namespace Application.Queries.Vehicles.VehiclesQueryRelated;

internal sealed class VehiclesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    ListQueryHandlerBase<Vehicle, VehicleFilteringRequestParameters, VehicleDto>(unitOfWork, mapper),
    IRequestHandler<VehiclesQuery, Result<PaginationResult<VehicleDto>>>
{
    public Task<Result<PaginationResult<VehicleDto>>> Handle(VehiclesQuery request,
        CancellationToken cancellationToken) =>
        base.Handle(request, cancellationToken);
}