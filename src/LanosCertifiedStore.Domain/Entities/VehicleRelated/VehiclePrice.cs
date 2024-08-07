﻿using LanosCertifiedStore.Domain.Contracts.Common;

namespace LanosCertifiedStore.Domain.Entities.VehicleRelated;

public sealed class VehiclePrice : IIdentifiable<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public decimal Value { get; set; }
    public DateTime IssueDate { get; set; } = DateTime.UtcNow;
    public Guid VehicleId { get; set; }
    public Vehicle Vehicle { get; set; } = null!;

    public VehiclePrice() { }
    
    public VehiclePrice(Guid vehicleId, decimal value)
    {
        VehicleId = vehicleId;
        Value = value;
    }
}
