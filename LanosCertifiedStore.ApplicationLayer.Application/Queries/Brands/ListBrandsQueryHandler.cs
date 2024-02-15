using Application.Core;
using Application.Dtos.BrandDtos;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Brands;

internal sealed class ListBrandsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<ListBrandsQuery, Result<IReadOnlyList<BrandDto>>>
{
    public async Task<Result<IReadOnlyList<BrandDto>>> Handle(ListBrandsQuery request,
        CancellationToken cancellationToken)
    {
        var brands = await unitOfWork.RetrieveRepository<VehicleBrand>().GetAllEntitiesAsync();

        var brandsToReturn = mapper.Map<IReadOnlyList<VehicleBrand>, IReadOnlyList<BrandDto>>(brands);

        return Result<IReadOnlyList<BrandDto>>.Success(brandsToReturn);
    }
}