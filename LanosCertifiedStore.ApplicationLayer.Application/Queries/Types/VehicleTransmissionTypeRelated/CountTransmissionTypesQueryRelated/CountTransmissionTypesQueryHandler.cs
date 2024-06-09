using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Types.VehicleTransmissionTypeRelated.CountTransmissionTypesQueryRelated;

internal sealed class CountTransmissionTypesQueryHandler(IUnitOfWork unitOfWork) : 
    CountItemsQueryHandlerBase<VehicleTransmissionType>(unitOfWork),
    IRequestHandler<CountTransmissionTypesQuery, Result<ItemsCountDto>>
{
    public Task<Result<ItemsCountDto>> Handle(
        CountTransmissionTypesQuery request, CancellationToken cancellationToken) =>
        base.Handle(request, cancellationToken);
}