using Application.Commands.VehicleBrandsRelated.Shared.ValidatorRelated;
using Application.Contracts.ValidationRelated;

namespace Application.Commands.VehicleBrandsRelated.CreateVehicleBrandRelated;

// TODO
internal sealed class CreateVehicleBrandCommandValidator : VehicleBrandValidatorBase<CreateVehicleBrandCommandRequest>
{
    public CreateVehicleBrandCommandValidator(IValidationHelper validationHelper) : base(validationHelper)
    {
        GetNameLengthValidationRule(x => x.Name);
        GetNameUniquenessValidationRule(x => x.Name);
    }
}