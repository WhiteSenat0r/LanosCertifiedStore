using Application.Contracts.RepositoryRelated.Common;
using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Application.Shared;
using Domain.Models.VehicleRelated.Classes.TypeRelated;
using MediatR;

namespace Application.Queries.Types.VehicleTransmissionTypeRelated.CountTransmissionTypesQueryRelated;

// TODO
// internal sealed class CountTransmissionTypesQueryHandler(IUnitOfWork unitOfWork) : 
//     CountItemsQueryHandlerBase<VehicleTransmissionType>(unitOfWork),
//     IRequestHandler<CountTransmissionTypesQuery, Result<ItemsCountDto>>
// {
//     public Task<Result<ItemsCountDto>> Handle(
//         CountTransmissionTypesQuery request, CancellationToken cancellationToken) =>
//         base.Handle(request, cancellationToken);
// }