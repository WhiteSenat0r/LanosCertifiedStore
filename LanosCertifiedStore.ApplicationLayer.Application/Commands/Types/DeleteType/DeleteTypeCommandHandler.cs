using Application.Commands.Common;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Types.DeleteType;

internal sealed class DeleteTypeCommandHandler : CommandBase<Unit>, IRequestHandler<DeleteTypeCommand, Result<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTypeCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _unitOfWork = unitOfWork;
        PossibleErrorMessages = 
            ["Removing a type was not successful!", "Error occured during the type removal!"];
        PossibleErrorCode = "DeleteTypeError";
    }

    public async Task<Result<Unit>> Handle(DeleteTypeCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.RetrieveRepository<VehicleType>().RemoveExistingEntity(request.Id);

        return await TrySaveChanges(cancellationToken);
    }
}