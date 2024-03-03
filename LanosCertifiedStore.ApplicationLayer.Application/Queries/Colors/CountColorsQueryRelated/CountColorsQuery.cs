using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Colors.CountColorsQueryRelated;

public sealed record CountColorsQuery(IFilteringRequestParameters<VehicleColor> RequestParameters) : 
    CountItemsQueryBase<VehicleColor>(RequestParameters), IRequest<Result<ItemsCountDto>>;