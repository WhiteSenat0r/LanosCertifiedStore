using Application.Core.Results;
using Application.Dtos.VehicleDtos;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Vehicles.ListVehicles;

internal sealed class ListVehiclesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<ListVehiclesQuery, Result<PaginationResult<ListVehicleDto>>>
{
    public async Task<Result<PaginationResult<ListVehicleDto>>> Handle(ListVehiclesQuery request,
        CancellationToken cancellationToken)
    {
        var vehicles = await unitOfWork.RetrieveRepository<Vehicle>().GetAllEntitiesAsync(
            request.RequestParameters);

        var mappedVehicles = mapper.Map<IReadOnlyList<Vehicle>, IReadOnlyList<ListVehicleDto>>(vehicles);

        var returnedResult = new PaginationResult<ListVehicleDto>(
            items: mappedVehicles,
            pageIndex: request.RequestParameters.PageIndex);

        return Result<PaginationResult<ListVehicleDto>>.Success(returnedResult);
    }
}