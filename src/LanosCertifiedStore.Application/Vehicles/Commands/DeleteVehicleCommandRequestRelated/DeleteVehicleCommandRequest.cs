using LanosCertifiedStore.Application.Shared.RequestRelated;

namespace LanosCertifiedStore.Application.Vehicles.Commands.DeleteVehicleCommandRequestRelated;

public record DeleteVehicleCommandRequest(Guid Id) : ICommandRequest;