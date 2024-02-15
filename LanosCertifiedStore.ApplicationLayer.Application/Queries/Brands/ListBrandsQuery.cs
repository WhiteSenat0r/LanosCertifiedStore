using Application.Core;
using Application.Dtos.BrandDtos;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Brands;

public sealed record ListBrandsQuery : IRequest<Result<IReadOnlyList<BrandDto>>>;