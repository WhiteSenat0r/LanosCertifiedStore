using LanosCertifiedStore.Application.Images.Commands.AddImageToVehicleCommandRequestRelated;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace ApplicationUnitTests.Images.AddImageToVehicleCommand;

public static class AddImagesToVehicleCommandRequestTestExemplars
{
    public static AddImagesToVehicleCommandRequest Regular()
    {
        return new AddImagesToVehicleCommandRequest(
            VehicleId: Guid.NewGuid(),
            Images: new List<IFormFile>() { new FormFile(default, default, default, default, default) }
        );
    }

    public static AddImagesToVehicleCommandRequest WithEmptyImages()
    {
        return new AddImagesToVehicleCommandRequest(
            VehicleId: Guid.NewGuid(),
            Images: new List<IFormFile>()
        );
    }

    public static AddImagesToVehicleCommandRequest WithMultipleImages()
    {
        return new AddImagesToVehicleCommandRequest(
            VehicleId: Guid.NewGuid(),
            Images: new List<IFormFile>() { new FormFile(default, default, default, default, default), new FormFile(default, default, default, default, default), new FormFile(default, default, default, default, default) }
        );
    }

    public static AddImagesToVehicleCommandRequest WithInvalidVehicleId()
    {
        return new AddImagesToVehicleCommandRequest(
            VehicleId: Guid.Empty,
            Images: new List<IFormFile>() { new FormFile(default, default, default, default, default) }
        );
    }
}