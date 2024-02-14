using Application.Core;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Commands.Types.DeleteType;

internal sealed class DeleteTypeCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteTypeCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(DeleteTypeCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.RetrieveRepository<VehicleType>().RemoveExistingEntity(request.Id);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failed to delete type!");
    }
}