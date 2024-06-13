using Application.Contracts.RepositoryRelated.Common;
using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Application.Shared;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using MediatR;

namespace Application.Queries.Types.VehicleEngineTypeRelated.CountEngineTypesQueryRelated;

public sealed record CountEngineTypesQuery(IFilteringRequestParameters<VehicleEngineType> RequestParameters) : 
    CountItemsQueryBase<VehicleEngineType>(RequestParameters), IRequest<Result<ItemsCountDto>>;