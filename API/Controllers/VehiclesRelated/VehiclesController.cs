using API.Controllers.Common;
using Application.Commands.Vehicles.CreateVehicle;
using Application.Dtos.VehicleDtos;
using Application.Queries.Vehicles.ListVehicles;
using Application.Queries.Vehicles.VehicleDetails;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.VehiclesRelated;

public sealed class VehiclesController : BaseEntityRelatedApiController
{
    [HttpGet]
    public async Task<IActionResult> GetVehicles()
    {
        return HandleResult(await Mediator.Send(new ListVehiclesQuery()));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetVehicle(Guid id)
    {
        return HandleResult(await Mediator.Send(new VehicleDetailsQuery(id)));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateVehicle([FromBody] CreateVehicleDto vehicle)
    {
        return HandleResult(await Mediator.Send(new CreateVehicleCommand(vehicle)));
    }
}