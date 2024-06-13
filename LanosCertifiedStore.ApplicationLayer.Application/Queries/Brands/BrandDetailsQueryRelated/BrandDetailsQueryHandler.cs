using Application.Contracts.RepositoryRelated.Common;
using Application.Dtos.BrandDtos;
using Application.Queries.Common.DetailsQueryRelated;
using Application.Shared;
using AutoMapper;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Queries.Brands.BrandDetailsQueryRelated;

internal sealed class BrandDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    DetailsQueryHandlerBase<VehicleBrand, BrandDto>(unitOfWork, mapper),
    IRequestHandler<BrandDetailsQuery, Result<BrandDto>>
{
    public Task<Result<BrandDto>> Handle(BrandDetailsQuery request,
        CancellationToken cancellationToken) =>
        base.Handle(request, cancellationToken);
}