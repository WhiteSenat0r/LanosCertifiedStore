using Application.Core.Results;
using Application.Dtos.ColorDtos;
using Application.Queries.Common.QueryRelated;
using Application.RequestParams;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Colors;

internal sealed class ColorsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    ListQueryHandlerBase<VehicleColor, VehicleColorFilteringRequestParameters, ColorDto>(unitOfWork, mapper), 
    IRequestHandler<ColorsQuery, Result<PaginationResult<ColorDto>>>
{
    public Task<Result<PaginationResult<ColorDto>>> Handle(ColorsQuery request,
        CancellationToken cancellationToken) =>
        base.Handle(request, cancellationToken);
}