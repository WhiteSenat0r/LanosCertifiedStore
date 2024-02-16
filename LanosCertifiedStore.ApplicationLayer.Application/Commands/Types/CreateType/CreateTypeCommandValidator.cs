using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using FluentValidation;

namespace Application.Commands.Types.CreateType;

internal sealed class CreateTypeCommandValidator : AbstractValidator<CreateTypeCommand>
{
    public CreateTypeCommandValidator(IUnitOfWork unitOfWork)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(64)
            .MinimumLength(2);

        RuleFor(x => x.Name)
            .MustAsync(async (name, _) =>
            {
                var types = await unitOfWork.RetrieveRepository<VehicleType>().GetAllEntitiesAsync();
                return types.All(x => x.Name != name);
            })
            .WithMessage("Type with such name already exists! Type name must be unique");
    }
}