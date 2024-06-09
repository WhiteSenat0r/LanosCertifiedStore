using Application.Core.Results;
using Application.Dtos.TypeDtos;
using Application.Queries.Common.QueryRelated;
using AutoMapper;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Types.VehicleTypeRelated;

internal sealed class VehicleTypesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    ListQueryHandlerBase<VehicleType, IFilteringRequestParameters<VehicleType>, VehicleTypeDto>(unitOfWork, mapper),
    IRequestHandler<VehicleTypesQuery, Result<PaginationResult<VehicleTypeDto>>>
{
    public Task<Result<PaginationResult<VehicleTypeDto>>> Handle(VehicleTypesQuery request,
        CancellationToken cancellationToken) =>
        base.Handle(request, cancellationToken);
}