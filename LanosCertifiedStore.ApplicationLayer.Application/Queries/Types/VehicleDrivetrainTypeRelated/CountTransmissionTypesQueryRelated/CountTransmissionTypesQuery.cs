using Application.Contracts.RepositoryRelated.Common;
using Application.Dtos.Common;
using Application.Queries.Common.CountItemsQueryRelated;
using Application.Shared;
using Domain.Models.VehicleRelated.Classes.TypeRelated;
using MediatR;

namespace Application.Queries.Types.VehicleDrivetrainTypeRelated.CountTransmissionTypesQueryRelated;

public sealed record CountDrivetrainTypesQuery(
    IFilteringRequestParameters<VehicleDrivetrainType> RequestParameters) : 
    CountItemsQueryBase<VehicleDrivetrainType>(RequestParameters), IRequest<Result<ItemsCountDto>>;