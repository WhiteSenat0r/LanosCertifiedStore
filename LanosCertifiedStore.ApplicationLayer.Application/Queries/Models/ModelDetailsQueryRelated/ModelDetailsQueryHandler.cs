using Application.Contracts.RepositoryRelated.Common;
using Application.Dtos.ModelDtos;
using Application.Queries.Common.DetailsQueryRelated;
using Application.Shared;
using AutoMapper;
using Domain.Models.VehicleRelated.Classes;
using MediatR;

namespace Application.Queries.Models.ModelDetailsQueryRelated;

// TODO
// internal sealed class ModelDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) :
//     DetailsQueryHandlerBase<VehicleModel, ModelDto>(unitOfWork, mapper),
//     IRequestHandler<ModelDetailsQuery, Result<ModelDto>>
// {
//     public Task<Result<ModelDto>> Handle(ModelDetailsQuery request,
//         CancellationToken cancellationToken) =>
//         base.Handle(request, cancellationToken);
// }