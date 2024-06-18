using Application.Contracts.RepositoryRelated.Common;
using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Application.Shared;
using Domain.Models.VehicleRelated.Classes;
using MediatR;

namespace Application.Queries.Colors.CountColorsQueryRelated;

// TODO
// internal sealed class CountColorsQueryHandler(IUnitOfWork unitOfWork) : 
//     CountItemsQueryHandlerBase<VehicleColor>(unitOfWork),
//     IRequestHandler<CountColorsQuery, Result<ItemsCountDto>>
// {
//     public Task<Result<ItemsCountDto>> Handle(
//         CountColorsQuery request, CancellationToken cancellationToken) =>
//         base.Handle(request, cancellationToken);
// }