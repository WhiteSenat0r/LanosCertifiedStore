using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using FluentValidation;

namespace Application.Commands.Displacements.UpdateDisplacement;

internal sealed class UpdateDisplacementCommandValidator : AbstractValidator<UpdateDisplacementCommand>
{
    public UpdateDisplacementCommandValidator(IUnitOfWork unitOfWork)
    {
        RuleFor(x => x.UpdateDisplacementDto.UpdatedValue)
            .NotEmpty()
            .GreaterThan(0.1)
            .LessThan(100);

        RuleFor(x => x.UpdateDisplacementDto.UpdatedValue)
            .MustAsync(async (value, _) =>
            {
                var displacements = await unitOfWork.RetrieveRepository<VehicleDisplacement>().GetAllEntitiesAsync();
                return displacements.All(x => x.Value != value);
            })
            .WithMessage("Value must be unique!");
    }
}