using Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Commands.Vehicles.Common;

public interface IActionVehicleCommandBase : IRequest<Result<Unit>>
{
    Guid ModelId { get; }
    Guid TypeId { get; }
    Guid ColorId { get; }
    string Description { get; }
    double Displacement { get; }
    decimal Price { get; }
}