﻿using LanosCertifiedStore.Domain.Contracts.Common;

namespace LanosCertifiedStore.Domain.Entities.Common.Classes;

public abstract class NamedAspect : IIdentifiable<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = null!;

    protected NamedAspect() { }
    protected NamedAspect(string name) => Name = name;
}