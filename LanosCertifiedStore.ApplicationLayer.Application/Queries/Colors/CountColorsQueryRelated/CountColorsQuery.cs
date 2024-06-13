using Application.Contracts.RepositoryRelated.Common;
using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Application.Shared;
using Domain.Models.VehicleRelated.Classes;
using MediatR;

namespace Application.Queries.Colors.CountColorsQueryRelated;

public sealed record CountColorsQuery(IFilteringRequestParameters<VehicleColor> RequestParameters) : 
    CountItemsQueryBase<VehicleColor>(RequestParameters), IRequest<Result<ItemsCountDto>>;