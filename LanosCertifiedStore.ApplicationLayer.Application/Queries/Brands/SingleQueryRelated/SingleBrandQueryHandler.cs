﻿using Application.Dtos.BrandDtos;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Brands.SingleQueryRelated;

internal sealed class SingleBrandQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<SingleBrandQuery, Result<BrandDto>>
{
    public async Task<Result<BrandDto>> Handle(SingleBrandQuery request,
        CancellationToken cancellationToken)
    {
        var brand = await unitOfWork.RetrieveRepository<VehicleBrand>()
            .GetEntityByIdAsync(request.Id);

        if (brand is null) return null!;
        
        var brandToReturn = mapper.Map<VehicleBrand, BrandDto>(brand);

        return Result<BrandDto>.Success(brandToReturn);
    }
}