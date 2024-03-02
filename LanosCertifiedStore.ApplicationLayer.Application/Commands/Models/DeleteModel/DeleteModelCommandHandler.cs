using Application.Commands.Common;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Models.DeleteModel;

internal sealed class DeleteModelCommandHandler : CommandHandlerBase<Unit>,
    IRequestHandler<DeleteModelCommand, Result<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteModelCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _unitOfWork = unitOfWork;
        PossibleErrors = new[]
        {
            new Error("DeleteModelError", "Model removal was not successful!"),
            new Error("DeleteModelError", "Error occured during the color removal!")
        };
    }

    public async Task<Result<Unit>> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.RetrieveRepository<VehicleModel>().RemoveExistingEntityAsync(request.Id);

        return await TrySaveChanges(cancellationToken);
    }
}