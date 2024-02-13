using Application.Core;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Commands.Types.DeleteType;

internal sealed class DeleteTypeCommandHandler(IRepository<VehicleType> typeRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteTypeCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(DeleteTypeCommand request, CancellationToken cancellationToken)
    {
        var deletedType = await typeRepository.GetEntityByIdAsync(request.Id);

        if (deletedType is null)
            return Result<Unit>.Failure("Such type doesn't exists!");
        
        typeRepository.RemoveExistingEntity(deletedType);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failed to delete type!");
    }
}