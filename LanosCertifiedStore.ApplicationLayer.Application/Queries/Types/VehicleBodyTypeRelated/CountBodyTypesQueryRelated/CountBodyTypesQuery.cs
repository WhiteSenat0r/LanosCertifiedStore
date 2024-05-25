using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Types.VehicleBodyTypeRelated.CountBodyTypesQueryRelated;

public sealed record CountBodyTypesQuery(IFilteringRequestParameters<VehicleEngineType> RequestParameters) : 
    CountItemsQueryBase<VehicleEngineType>(RequestParameters), IRequest<Result<ItemsCountDto>>;