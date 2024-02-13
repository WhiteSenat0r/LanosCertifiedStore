﻿using System.ComponentModel.DataAnnotations;
using Domain.Contracts.Common;

namespace Persistence.DataModels.Common.Classes;

internal abstract class NamedVehicleAspect : IEntity<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    [MaxLength(64)] public string Name { get; set; } = null!;

    protected NamedVehicleAspect() { }
    protected NamedVehicleAspect(string name) => Name = name;
}