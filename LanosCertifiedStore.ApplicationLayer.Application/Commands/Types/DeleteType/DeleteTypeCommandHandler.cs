using Application.Commands.Common;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Types.DeleteType;

internal sealed class DeleteTypeCommandHandler : 
    CommandHandlerBase<Unit>, IRequestHandler<DeleteTypeCommand, Result<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTypeCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _unitOfWork = unitOfWork;
        PossibleErrors = new[]
        {
            new Error("DeleteTypeError", "Type removal was not successful!"),
            new Error("DeleteTypeError", "Error occured during the type removal!")
        };
    }

    public async Task<Result<Unit>> Handle(DeleteTypeCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.RetrieveRepository<VehicleType>().RemoveExistingEntityAsync(request.Id);

        return await TrySaveChanges(cancellationToken);
    }
}