using Application.Core.Results;
using Application.Dtos.TypeDtos;
using Application.Queries.Common.QueryRelated;
using AutoMapper;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Types.VehicleDrivetrainTypeRelated;

internal sealed class VehicleDrivetrainTypesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    ListQueryHandlerBase<VehicleDrivetrainType,
        IFilteringRequestParameters<VehicleDrivetrainType>,
        VehicleDrivetrainTypeDto>(unitOfWork, mapper),
    IRequestHandler<VehicleDrivetrainTypesQuery, Result<PaginationResult<VehicleDrivetrainTypeDto>>>
{
    public Task<Result<PaginationResult<VehicleDrivetrainTypeDto>>> Handle(VehicleDrivetrainTypesQuery request,
        CancellationToken cancellationToken) =>
        base.Handle(request, cancellationToken);
}