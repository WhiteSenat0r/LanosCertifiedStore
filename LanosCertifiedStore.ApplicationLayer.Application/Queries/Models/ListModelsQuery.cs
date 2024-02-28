using Application.Dtos.ModelDtos;
using Domain.Contracts.RequestParametersRelated;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Models;

public sealed record ListModelsQuery(IVehicleModelFilteringRequestParameters RequestParameters)
    : IRequest<Result<IReadOnlyList<ModelDto>>>;