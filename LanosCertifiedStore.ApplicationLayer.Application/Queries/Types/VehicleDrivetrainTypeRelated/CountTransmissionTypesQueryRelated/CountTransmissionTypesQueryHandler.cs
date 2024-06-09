using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Types.VehicleDrivetrainTypeRelated.CountTransmissionTypesQueryRelated;

internal sealed class CountDrivetrainTypesQueryHandler(IUnitOfWork unitOfWork) : 
    CountItemsQueryHandlerBase<VehicleDrivetrainType>(unitOfWork),
    IRequestHandler<CountDrivetrainTypesQuery, Result<ItemsCountDto>>
{
    public Task<Result<ItemsCountDto>> Handle(
        CountDrivetrainTypesQuery request, CancellationToken cancellationToken) =>
        base.Handle(request, cancellationToken);
}