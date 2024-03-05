using Application.Dtos.BrandDtos;
using Application.Queries.Common.DetailsQueryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Brands.BrandDetailsQueryRelated;

public sealed record BrandDetailsQuery(Guid Id) : DetailsQueryBase<VehicleBrand>(Id), IRequest<Result<BrandDto>>;