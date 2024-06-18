using Application.Contracts.RepositoryRelated.Common;
using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Application.Shared;
using Domain.Models.VehicleRelated.Classes;
using MediatR;

namespace Application.Queries.Models.CountModelsQueryRelated;

// TODO
// internal sealed class CountModelsQueryHandler(IUnitOfWork unitOfWork) : 
//     CountItemsQueryHandlerBase<VehicleModel>(unitOfWork),
//     IRequestHandler<CountModelsQuery, Result<ItemsCountDto>>
// {
//     public Task<Result<ItemsCountDto>> Handle(
//         CountModelsQuery request, CancellationToken cancellationToken) =>
//         base.Handle(request, cancellationToken);
// }