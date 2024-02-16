using Application.Dtos.BrandDtos;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Brands.BrandDetails;

public sealed record BrandDetailsQuery(Guid Id) : IRequest<Result<BrandDto>>;