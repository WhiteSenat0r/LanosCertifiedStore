using Application.Contracts.RepositoryRelated.Common;
using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Application.Shared;
using Domain.Models.VehicleRelated.Classes.TypeRelated;
using MediatR;

namespace Application.Queries.Types.VehicleTransmissionTypeRelated.CountTransmissionTypesQueryRelated;

public sealed record CountTransmissionTypesQuery(
    IFilteringRequestParameters<VehicleTransmissionType> RequestParameters) : 
    CountItemsQueryBase<VehicleTransmissionType>(RequestParameters), IRequest<Result<ItemsCountDto>>;