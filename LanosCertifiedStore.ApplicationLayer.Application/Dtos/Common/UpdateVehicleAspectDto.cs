namespace Application.Dtos.Common;

public abstract class UpdateVehicleAspectDto
{
    public Guid Id { get; set; }
    public string UpdatedName { get; set; }
}