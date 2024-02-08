﻿using API.Controllers.Common;
using Application.Commands.Models.CreateModel;
using Application.Commands.Models.DeleteModel;
using Application.Commands.Models.UpdateModel;
using Application.Dtos.ModelDtos;
using Application.Queries.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.VehiclesRelated;

public sealed class ModelsController : BaseEntityRelatedApiController
{
    [HttpGet]
    public async Task<IActionResult> GetModels()
    {
        return HandleResult(await Mediator.Send(new ListModelsQuery()));
    }

    [HttpPost]
    public async Task<IActionResult> CreateModel([FromQuery] string name)
    {
        return HandleResult(await Mediator.Send(new CreateModelCommand(name)));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateModel([FromBody] UpdateModelDto updateBrandDto)
    {
        return HandleResult(await Mediator.Send(new UpdateModelCommand(updateBrandDto)));
    }

    [HttpDelete("{name}")]
    public async Task<IActionResult> DeleteModel(string name)
    {
        return HandleResult(await Mediator.Send(new DeleteModelCommand(name)));
    }
}