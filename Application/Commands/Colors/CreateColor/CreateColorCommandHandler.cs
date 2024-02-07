using Application.Core;
using Application.QuerySpecifications.ColorRelated;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Commands.Colors.CreateColor;

internal sealed class CreateColorCommandHandler(IRepository<VehicleColor> colorRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateColorCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(CreateColorCommand request, CancellationToken cancellationToken)
    {
        var existingColor =
            await colorRepository.GetSingleEntityBySpecificationAsync(new ColorQuerySpecification(request.ColorName));

        if (existingColor is not null) return Result<Unit>.Failure("Such color already exists!");

        var color = new VehicleColor(request.ColorName);

        await colorRepository.AddNewEntityAsync(color);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failed to create color!");
    }
}