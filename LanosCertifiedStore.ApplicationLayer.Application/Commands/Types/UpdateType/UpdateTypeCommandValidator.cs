using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using FluentValidation;

namespace Application.Commands.Types.UpdateType;

internal sealed class UpdateTypeCommandValidator : AbstractValidator<UpdateTypeCommand>
{
    public UpdateTypeCommandValidator(IUnitOfWork unitOfWork)
    {
        RuleFor(x => x.UpdateTypeDto.UpdatedName)
            .NotEmpty()
            .MaximumLength(64)
            .MinimumLength(2);

        RuleFor(x => x.UpdateTypeDto.UpdatedName)
            .MustAsync(async (name, _) =>
            {
                var types = await unitOfWork.RetrieveRepository<VehicleType>().GetAllEntitiesAsync();
                return types.All(x => x.Name != name);
            })
            .WithMessage("Type with such name already exists! Type name must be unique");
    }
}