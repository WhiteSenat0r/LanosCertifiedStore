using API.Controllers.Common;
using Application.Commands.Vehicles.CreateVehicle;
using Application.Dtos.VehicleDtos;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.VehiclesRelated;

public sealed class VehiclesController : BaseEntityRelatedApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateVehicle([FromBody] CreateVehicleDto vehicle)
    {
        return HandleResult(await Mediator.Send(new CreateVehicleCommand(vehicle)));
    }
}