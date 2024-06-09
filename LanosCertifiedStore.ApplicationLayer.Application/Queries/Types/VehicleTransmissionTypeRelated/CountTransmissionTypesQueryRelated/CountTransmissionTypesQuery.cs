using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Types.VehicleTransmissionTypeRelated.CountTransmissionTypesQueryRelated;

public sealed record CountTransmissionTypesQuery(
    IFilteringRequestParameters<VehicleTransmissionType> RequestParameters) : 
    CountItemsQueryBase<VehicleTransmissionType>(RequestParameters), IRequest<Result<ItemsCountDto>>;