using Application.Commands.Common;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Colors.DeleteColor;

internal sealed class DeleteColorCommandHandler 
    : CommandHandlerBase<Unit>, IRequestHandler<DeleteColorCommand, Result<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteColorCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _unitOfWork = unitOfWork;
        PossibleErrors = new[]
        {
            new Error("DeleteColorError", "Removing a brand was not successful!"),
            new Error("DeleteColorError", "Error occured during the color removal!")
        };
    }

    public async Task<Result<Unit>> Handle(DeleteColorCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.RetrieveRepository<VehicleColor>().RemoveExistingEntityAsync(request.Id);

        return await TrySaveChanges(cancellationToken);
    }
}