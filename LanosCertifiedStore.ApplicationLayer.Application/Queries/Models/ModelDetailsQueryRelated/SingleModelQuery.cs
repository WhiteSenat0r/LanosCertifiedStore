using Application.Dtos.ModelDtos;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Models.ModelDetailsQueryRelated;

public sealed record SingleModelQuery(Guid Id) : IRequest<Result<ModelDto>>;