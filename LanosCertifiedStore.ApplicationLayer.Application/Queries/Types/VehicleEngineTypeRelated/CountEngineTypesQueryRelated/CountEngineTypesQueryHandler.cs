using Application.Contracts.RepositoryRelated.Common;
using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Application.Shared;
using Domain.Models.VehicleRelated.Classes.TypeRelated;
using MediatR;

namespace Application.Queries.Types.VehicleEngineTypeRelated.CountEngineTypesQueryRelated;

// TODO
// internal sealed class CountEngineTypesQueryHandler(IUnitOfWork unitOfWork) : 
//     CountItemsQueryHandlerBase<VehicleEngineType>(unitOfWork),
//     IRequestHandler<CountEngineTypesQuery, Result<ItemsCountDto>>
// {
//     public Task<Result<ItemsCountDto>> Handle(
//         CountEngineTypesQuery request, CancellationToken cancellationToken) =>
//         base.Handle(request, cancellationToken);
// }