using Application.Dtos.ModelDtos;
using Domain.Contracts.RequestParametersRelated;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Models.ModelQueryRelated;

public sealed record ModelsQuery(IVehicleModelFilteringRequestParameters RequestParameters)
    : IRequest<Result<IReadOnlyList<ModelDto>>>;