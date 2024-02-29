using Application.Dtos.BrandDtos;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Brands.SingleQueryRelated;

public sealed record SingleBrandQuery(Guid Id) : IRequest<Result<BrandDto>>;