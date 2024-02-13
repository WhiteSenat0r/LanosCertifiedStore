using Application.Core;
using Application.QuerySpecifications.ColorRelated;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Commands.Colors.DeleteColor;

internal sealed class DeleteColorCommandHandler(IRepository<VehicleColor> colorRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteColorCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(DeleteColorCommand request, CancellationToken cancellationToken)
    {
        var color = await colorRepository.GetSingleEntityBySpecificationAsync(
            new ColorByNameQuerySpecification(request.ColorName));

        if (color is null)
            return Result<Unit>.Failure("Such color doesn't exists!");

        colorRepository.RemoveExistingEntity(color);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failed to delete brand");
    }
}