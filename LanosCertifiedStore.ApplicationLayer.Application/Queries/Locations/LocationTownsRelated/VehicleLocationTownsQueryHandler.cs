using Application.Contracts.RepositoryRelated.Common;
using Application.Core.Results;
using Application.Dtos.LocationDtos;
using Application.Queries.Common.QueryRelated;
using Application.Shared;
using AutoMapper;
using Domain.Models.VehicleRelated.Classes.LocationRelated;
using MediatR;

namespace Application.Queries.Locations.LocationTownsRelated;

// TODO
// internal sealed class VehicleLocationTownsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) :
//     ListQueryHandlerBase<VehicleLocationTown, IFilteringRequestParameters<VehicleLocationTown>, TownDto>(
//         unitOfWork, mapper),
//     IRequestHandler<VehicleLocationTownsQuery, Result<PaginationResult<TownDto>>>
// {
//     public Task<Result<PaginationResult<TownDto>>> Handle(VehicleLocationTownsQuery request,
//         CancellationToken cancellationToken) =>
//         base.Handle(request, cancellationToken);
// }