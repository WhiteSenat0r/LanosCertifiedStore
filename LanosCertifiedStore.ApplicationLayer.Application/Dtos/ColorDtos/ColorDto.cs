﻿using Application.Dtos.Common;

namespace Application.Dtos.ColorDtos;

public sealed record ColorDto : VehicleAspectDto
{
    public string? HexValue { get; set; }
}