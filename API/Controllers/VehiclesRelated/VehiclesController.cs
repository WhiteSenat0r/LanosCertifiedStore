using API.Controllers.Common;
using Application.Vehicles.CreateVehicle;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.VehiclesRelated;

public sealed class VehiclesController : BaseEntityRelatedApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateVehicle(Vehicle vehicle)
    {
        return HandleResult(await Mediator.Send(new CreateVehicleCommand(vehicle)));
    }
}