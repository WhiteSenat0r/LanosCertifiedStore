using Application.Contracts.RepositoryRelated.Common;
using Application.Core.Results;
using Application.Dtos.ColorDtos;
using Application.Queries.Common.QueryRelated;
using Application.RequestParams;
using Application.Shared;
using AutoMapper;
using Domain.Models.VehicleRelated.Classes;
using MediatR;

namespace Application.Queries.Colors;

// TODO
// internal sealed class ColorsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) :
//     ListQueryHandlerBase<VehicleColor, VehicleColorFilteringRequestParameters, ColorDto>(unitOfWork, mapper), 
//     IRequestHandler<ColorsQuery, Result<PaginationResult<ColorDto>>>
// {
//     public Task<Result<PaginationResult<ColorDto>>> Handle(ColorsQuery request,
//         CancellationToken cancellationToken) =>
//         base.Handle(request, cancellationToken);
// }