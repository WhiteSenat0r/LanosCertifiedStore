using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Models.CountModelsQueryRelated;

public sealed record CountModelsQuery(IFilteringRequestParameters<VehicleModel> RequestParameters) : 
    CountItemsQueryBase<VehicleModel>(RequestParameters), IRequest<Result<ItemsCountDto>>;