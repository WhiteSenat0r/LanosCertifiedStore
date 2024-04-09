using Application.Core.Results;
using Application.Dtos.TypeDtos;
using Application.Queries.Common.QueryRelated;
using Application.RequestParams.TypeRelated;
using AutoMapper;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Types;

internal sealed class TypesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    ListQueryHandlerBase<VehicleType, VehicleTypeFilteringRequestParameters, VehicleTypeDto>(unitOfWork, mapper),
    IRequestHandler<TypesQuery, Result<PaginationResult<VehicleTypeDto>>>
{
    public Task<Result<PaginationResult<VehicleTypeDto>>> Handle(TypesQuery request,
        CancellationToken cancellationToken) =>
        base.Handle(request, cancellationToken);
}