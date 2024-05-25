using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Types.VehicleTypeRelated.CountTypesQueryRelated;

public sealed record CountTypesQuery(IFilteringRequestParameters<VehicleType> RequestParameters) : 
    CountItemsQueryBase<VehicleType>(RequestParameters), IRequest<Result<ItemsCountDto>>;