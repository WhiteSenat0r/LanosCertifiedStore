using Application.Core.Results;
using Application.Dtos.TypeDtos;
using Application.Queries.Common.QueryRelated;
using AutoMapper;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Types.VehicleBodyTypeRelated;

internal sealed class VehicleBodyTypesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    ListQueryHandlerBase<VehicleBodyType, IFilteringRequestParameters<VehicleBodyType>, VehicleBodyTypeDto>(
        unitOfWork, mapper),
    IRequestHandler<VehicleBodyTypesQuery, Result<PaginationResult<VehicleBodyTypeDto>>>
{
    public Task<Result<PaginationResult<VehicleBodyTypeDto>>> Handle(VehicleBodyTypesQuery request,
        CancellationToken cancellationToken) =>
        base.Handle(request, cancellationToken);
}