using Application.Core;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Commands.Colors.DeleteColor;

internal sealed class DeleteColorCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteColorCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(DeleteColorCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.RetrieveRepository<VehicleColor>().RemoveExistingEntity(request.Id);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failed to delete brand");
    }
}