using System.ComponentModel.DataAnnotations.Schema;
using Domain.Contracts.Common;

namespace Persistence.DataModels;

internal sealed class VehicleDisplacementDataModel : IEntity<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    [Column(TypeName = "decimal(6, 1)")] public double Value { get; set; }
    public ICollection<VehicleDataModel> Vehicles { get; set; } = new List<VehicleDataModel>();
    
    public VehicleDisplacementDataModel() { }
    public VehicleDisplacementDataModel(double value) => Value = value;
}
