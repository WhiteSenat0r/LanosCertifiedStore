using LanosCertifiedStore.Application.Shared.Dtos.CountItemsRelated;
using LanosCertifiedStore.Application.Shared.HandlersRelated.QueryRelated.CountItemsRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Domain.Abstractions.UnitOfWorkRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using MediatR;

namespace LanosCertifiedStore.Application.Vehicles.Queries.CountVehiclesQueryRelated;

internal sealed class CountVehiclesQueryHandler(IUnitOfWork unitOfWork) :
    CountItemsQueryRequestHandlerBase<Vehicle>(unitOfWork),
    IRequestHandler<CountVehiclesQueryRequest, Result<ItemsCountDto>>;