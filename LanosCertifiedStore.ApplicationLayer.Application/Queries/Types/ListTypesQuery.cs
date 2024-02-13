using Application.Core;
using Application.Dtos.TypeDtos;
using MediatR;

namespace Application.Queries.Types;

public sealed record ListTypesQuery : IRequest<Result<IReadOnlyList<TypeDto>>>;