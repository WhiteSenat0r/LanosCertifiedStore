using Application.Core;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Commands.Models.DeleteModel;

internal sealed class DeleteModelCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteModelCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.RetrieveRepository<VehicleModel>().RemoveExistingEntity(request.Id);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failed to delete model!");
    }
}