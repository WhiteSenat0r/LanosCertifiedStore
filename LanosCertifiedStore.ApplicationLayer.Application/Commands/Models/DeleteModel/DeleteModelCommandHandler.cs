using Application.Commands.Common;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Models.DeleteModel;

internal sealed class DeleteModelCommandHandler : CommandHandlerBase<Unit>,
    IRequestHandler<DeleteModelCommand, Result<Unit>>
{
    public DeleteModelCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        PossibleErrors =
        [
            new Error("DeleteModelError", "Model removal was not successful!"),
            new Error("DeleteModelError", "Error occured during the color removal!")
        ];
    }

    public async Task<Result<Unit>> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
    {
        await GetRequiredRepository<VehicleModel>().RemoveExistingEntityAsync(request.Id);

        return await TrySaveChanges(cancellationToken);
    }
}