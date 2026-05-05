using AutoMapper;
using LanosCertifiedStore.Application.Shared.HandlersRelated.QueryRelated.SingleRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using LanosCertifiedStore.Domain.Abstractions.UnitOfWorkRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using MediatR;

namespace LanosCertifiedStore.Application.Vehicles.Queries.VehicleDetailsQueryRelated;

internal sealed class VehicleDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    SingleQueryRequestHandlerBase<Vehicle, VehicleDto>(unitOfWork, mapper),
    IRequestHandler<VehicleSingleQueryRequest, Result<VehicleDto>>;