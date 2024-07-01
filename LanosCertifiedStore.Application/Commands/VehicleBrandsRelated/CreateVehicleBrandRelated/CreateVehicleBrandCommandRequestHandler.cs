using Application.Commands.Common;
using Application.Contracts.ServicesRelated.RequestRelated;
using Application.Dtos.BrandDtos;
using AutoMapper;
using Domain.Entities.VehicleRelated;

namespace Application.Commands.VehicleBrandsRelated.CreateVehicleBrandRelated;

internal sealed class CreateBrandCommandHandler(ICommandService commandService, IMapper mapper) : 
    CommandHandlerBase<VehicleBrand, CreateVehicleBrandCommandRequest, VehicleBrandDto>(
        commandService, mapper);