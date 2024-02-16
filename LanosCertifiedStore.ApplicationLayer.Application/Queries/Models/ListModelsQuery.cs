using Application.Dtos.ModelDtos;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Models;

public sealed record ListModelsQuery : IRequest<Result<IReadOnlyList<ModelDto>>>;