using AutoMapper;
using LanosCertifiedStore.Application.Shared.HandlersRelated.QueryRelated.CollectionRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using LanosCertifiedStore.Domain.Abstractions.UnitOfWorkRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using MediatR;

namespace LanosCertifiedStore.Application.Vehicles.Queries.VehiclesQueryRelated;

internal sealed class VehiclesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    CollectionQueryHandlerBase<Vehicle, VehicleFilteringRequestParameters, VehicleDto>(unitOfWork, mapper),
    IRequestHandler<VehiclesQueryRequest, Result<PaginationResult<VehicleDto>>>;