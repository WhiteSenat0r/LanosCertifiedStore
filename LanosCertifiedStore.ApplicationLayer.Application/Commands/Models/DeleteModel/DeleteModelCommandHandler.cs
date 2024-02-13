using Application.Core;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Commands.Models.DeleteModel;

internal sealed class DeleteModelCommandHandler(IRepository<VehicleModel> modelRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteModelCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
    {
        var deletedModel = await modelRepository.GetEntityByIdAsync(request.Id);

        if (deletedModel is null)
            return Result<Unit>.Failure("Such model doesn't exists!");
        
        modelRepository.RemoveExistingEntity(deletedModel);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failed to delete model!");
    }
}