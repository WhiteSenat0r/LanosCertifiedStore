using Application.Dtos.ModelDtos;
using Application.Queries.Common.DetailsQueryRelated;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Models.ModelDetailsQueryRelated;

internal sealed class ModelDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    DetailsQueryHandlerBase<VehicleModel, ModelDto>(unitOfWork, mapper),
    IRequestHandler<ModelDetailsQuery, Result<ModelDto>>
{
    public Task<Result<ModelDto>> Handle(ModelDetailsQuery request,
        CancellationToken cancellationToken) =>
        base.Handle(request, cancellationToken);
}