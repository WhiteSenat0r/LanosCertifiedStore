using Application.Core;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Commands.Colors.UpdateColor;

internal sealed class UpdateColorCommandHandler(IRepository<VehicleColor> colorRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateColorCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(UpdateColorCommand request, CancellationToken cancellationToken)
    {
        var existingColor = await colorRepository.GetEntityByIdAsync(request.UpdateColorDto.Id);

        if (existingColor is null) 
            return Result<Unit>.Failure("Such color doesn't exists!");
        
        existingColor.Name = request.UpdateColorDto.UpdatedName;

        colorRepository.UpdateExistingEntity(existingColor);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failed to update color");
    }
}