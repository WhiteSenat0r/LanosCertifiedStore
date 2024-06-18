using Application.Contracts.RepositoryRelated.Common;
using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Application.Shared;
using Domain.Models.VehicleRelated.Classes.TypeRelated;
using MediatR;

namespace Application.Queries.Types.VehicleTypeRelated.CountTypesQueryRelated;

public sealed record CountTypesQuery(IFilteringRequestParameters<VehicleType> RequestParameters) : 
    CountItemsQueryBase<VehicleType>(RequestParameters), IRequest<Result<ItemsCountDto>>;