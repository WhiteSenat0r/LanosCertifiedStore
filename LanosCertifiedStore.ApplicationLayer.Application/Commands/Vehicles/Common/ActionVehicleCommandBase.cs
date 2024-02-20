using Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Commands.Vehicles.Common;

public interface IActionVehicleCommandBase : IRequest<Result<Unit>>
{
    ICollection<IFormFile>? Images { get; }
    string? MainImageName { get; }
}