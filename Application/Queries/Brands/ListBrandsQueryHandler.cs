using Application.Core;
using Application.Dtos;
using Application.Dtos.BrandDtos;
using Application.QuerySpecifications.BrandRelated;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Queries.Brands;

internal sealed class ListBrandsQueryHandler(IRepository<VehicleBrand> brandRepository, IMapper mapper)
    : IRequestHandler<ListBrandsQuery, Result<IReadOnlyList<BrandDto>>>
{
    public async Task<Result<IReadOnlyList<BrandDto>>> Handle(ListBrandsQuery request,
        CancellationToken cancellationToken)
    {
        var brands = await brandRepository.GetAllEntitiesAsync(new BrandQuerySpecification());

        var brandsToReturn = mapper.Map<IReadOnlyList<VehicleBrand>, IReadOnlyList<BrandDto>>(brands);

        return Result<IReadOnlyList<BrandDto>>.Success(brandsToReturn);
    }
}