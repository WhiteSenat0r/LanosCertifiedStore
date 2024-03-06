using Application.Core.Results;
using Application.Dtos.ModelDtos;
using Application.Queries.Common.QueryRelated;
using Application.RequestParams;
using AutoMapper;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Models.ModelQueryRelated;

internal sealed class ModelsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    ListQueryHandlerBase<VehicleModel, VehicleModelFilteringRequestParameters, ModelDto>(unitOfWork, mapper),
    IRequestHandler<ModelsQuery, Result<PaginationResult<ModelDto>>>
{
    public Task<Result<PaginationResult<ModelDto>>> Handle(ModelsQuery request,
        CancellationToken cancellationToken) =>
        base.Handle(request, cancellationToken);
}