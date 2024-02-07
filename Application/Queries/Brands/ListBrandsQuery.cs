﻿using Application.Core;
using Application.Dtos;
using Application.Dtos.BrandDtos;
using MediatR;

namespace Application.Queries.Brands;

public sealed record ListBrandsQuery() : IRequest<Result<IReadOnlyList<BrandDto>>>;