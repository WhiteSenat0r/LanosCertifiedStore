using Application.Commands.Common;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Types.DeleteType;

internal sealed class DeleteTypeCommandHandlerHandler : CommandHandlerBase<Unit>, IRequestHandler<DeleteTypeCommand, Result<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTypeCommandHandlerHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _unitOfWork = unitOfWork;
        PossibleErrors = new[]
        {
            new Error("DeleteTypeError", "Removing a type was not successful!"),
            new Error("DeleteTypeError", "Error occured during the type removal!")
        };
    }

    public async Task<Result<Unit>> Handle(DeleteTypeCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.RetrieveRepository<VehicleType>().RemoveExistingEntity(request.Id);

        return await TrySaveChanges(cancellationToken);
    }
}