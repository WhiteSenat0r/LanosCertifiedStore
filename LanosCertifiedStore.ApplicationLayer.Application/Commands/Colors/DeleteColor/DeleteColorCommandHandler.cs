using Application.Commands.Common;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Colors.DeleteColor;

internal sealed class DeleteColorCommandHandler : CommandBase<Unit>, IRequestHandler<DeleteColorCommand, Result<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteColorCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _unitOfWork = unitOfWork;
        PossibleErrorMessages = 
            ["Removing a brand was not successful!", "Error occured during the color removal!"];
        PossibleErrorCode = "DeleteColorError";
    }

    public async Task<Result<Unit>> Handle(DeleteColorCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.RetrieveRepository<VehicleColor>().RemoveExistingEntity(request.Id);

        return await TrySaveChanges(cancellationToken);
    }
}