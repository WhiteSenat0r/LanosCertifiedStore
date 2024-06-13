using Application.Contracts.RepositoryRelated.Common;
using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Application.Shared;
using Domain.Models.VehicleRelated.Classes.TypeRelated;
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