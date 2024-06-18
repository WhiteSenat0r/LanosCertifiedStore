using Application.Contracts.RepositoryRelated.Common;
using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Application.Shared;
using Domain.Models.VehicleRelated.Classes.TypeRelated;
using MediatR;

namespace Application.Queries.Types.VehicleBodyTypeRelated.CountBodyTypesQueryRelated;

public sealed record CountBodyTypesQuery(IFilteringRequestParameters<VehicleBodyType> RequestParameters) : 
    CountItemsQueryBase<VehicleBodyType>(RequestParameters), IRequest<Result<ItemsCountDto>>;