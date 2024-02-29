using Application.Dtos.BrandDtos;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Brands.BrandDetailsQueryRelated;

internal sealed class BrandDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<BrandDetailsQuery, Result<BrandDto>>
{
    public async Task<Result<BrandDto>> Handle(BrandDetailsQuery request,
        CancellationToken cancellationToken)
    {
        var brand = await unitOfWork.RetrieveRepository<VehicleBrand>()
            .GetEntityByIdAsync(request.Id);

        if (brand is null) return null!;
        
        var brandToReturn = mapper.Map<VehicleBrand, BrandDto>(brand);

        return Result<BrandDto>.Success(brandToReturn);
    }
}