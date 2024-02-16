using Application.Core;
using Application.Dtos.BrandDtos;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Brands.UpdateBrand;

public sealed record UpdateBrandCommand(UpdateBrandDto UpdateBrandDto) : IRequest<Result<Unit>>;