using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using FluentValidation;

namespace Application.Commands.Displacements.CreateDisplacement;

internal sealed class CreateDisplacementCommandValidator : AbstractValidator<CreateDisplacementCommand>
{
    public CreateDisplacementCommandValidator(IUnitOfWork unitOfWork)
    {
        RuleFor(x => x.Value)
            .NotEmpty()
            .GreaterThan(0.1)
            .LessThan(100);

        RuleFor(x => x.Value)
            .MustAsync(async (value, _) =>
            {
                var displacements = await unitOfWork.RetrieveRepository<VehicleDisplacement>().GetAllEntitiesAsync();
                return displacements.All(x => x.Value != value);
            })
            .WithMessage("Value must be unique!");
    }
}