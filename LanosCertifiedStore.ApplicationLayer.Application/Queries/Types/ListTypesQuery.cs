using Application.Core;
using Application.Dtos.TypeDtos;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Types;

public sealed record ListTypesQuery : IRequest<Result<IReadOnlyList<TypeDto>>>;