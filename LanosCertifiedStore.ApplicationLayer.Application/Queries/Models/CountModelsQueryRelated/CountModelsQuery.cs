using Application.Contracts.RepositoryRelated.Common;
using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Application.Shared;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Queries.Models.CountModelsQueryRelated;

public sealed record CountModelsQuery(IFilteringRequestParameters<VehicleModel> RequestParameters) : 
    CountItemsQueryBase<VehicleModel>(RequestParameters), IRequest<Result<ItemsCountDto>>;