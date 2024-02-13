using Application.Core;
using Application.Dtos.ModelDtos;
using MediatR;

namespace Application.Queries.Models;

public sealed record ListModelsQuery : IRequest<Result<IReadOnlyList<ModelDto>>>;