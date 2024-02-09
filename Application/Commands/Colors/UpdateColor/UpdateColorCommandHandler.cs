using Application.Core;
using Application.QuerySpecifications.ColorRelated;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Commands.Colors.UpdateColor;

internal sealed class UpdateColorCommandHandler(IRepository<VehicleColor> colorRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateColorCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(UpdateColorCommand request, CancellationToken cancellationToken)
    {
        var existingColor = await colorRepository.GetSingleEntityBySpecificationAsync(
                new ColorByNameQuerySpecification(request.UpdateColorDto.CurrentName));

        if (existingColor is null) return null;
        
        var updatedValueColor = await colorRepository.GetSingleEntityBySpecificationAsync(
            new ColorByNameQuerySpecification(request.UpdateColorDto.UpdatedName));

        if (updatedValueColor is not null)
            return Result<Unit>.Failure("Color with such name already exists!");

        existingColor.Name = request.UpdateColorDto.UpdatedName;

        colorRepository.UpdateExistingEntity(existingColor);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failed to update color");
    }
}