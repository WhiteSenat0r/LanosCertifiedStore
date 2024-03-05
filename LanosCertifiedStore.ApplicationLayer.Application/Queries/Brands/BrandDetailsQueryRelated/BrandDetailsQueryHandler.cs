using Application.Dtos.BrandDtos;
using Application.Queries.Common.DetailsQueryRelated;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
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