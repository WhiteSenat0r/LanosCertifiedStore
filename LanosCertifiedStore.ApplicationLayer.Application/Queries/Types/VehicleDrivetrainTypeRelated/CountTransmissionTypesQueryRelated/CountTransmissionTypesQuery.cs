using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Types.VehicleDrivetrainTypeRelated.CountTransmissionTypesQueryRelated;

public sealed record CountDrivetrainTypesQuery(
    IFilteringRequestParameters<VehicleDrivetrainType> RequestParameters) : 
    CountItemsQueryBase<VehicleDrivetrainType>(RequestParameters), IRequest<Result<ItemsCountDto>>;