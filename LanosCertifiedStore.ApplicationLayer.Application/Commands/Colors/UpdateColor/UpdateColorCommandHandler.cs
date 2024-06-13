using Application.Commands.Common;
using Application.Contracts.RepositoryRelated.Common;
using Application.Shared;
using Domain.Models.VehicleRelated.Classes;
using MediatR;

namespace Application.Commands.Colors.UpdateColor;

internal sealed class UpdateColorCommandHandler 
    : CommandHandlerBase<Unit>, IRequestHandler<UpdateColorCommand, Result<Unit>>
{
    public UpdateColorCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        PossibleErrors =
        [
            new Error("UpdateColorError", "Saving an updated color was not successful!"),
            new Error("UpdateColorError", "Error occured during the color update!")
        ];
    }

    public async Task<Result<Unit>> Handle(UpdateColorCommand request, CancellationToken cancellationToken)
    {
        var colorRepository = GetRequiredRepository<VehicleColor>();
        var updatedColor = await colorRepository.GetEntityByIdAsync(request.Id);

        if (updatedColor is null) return Result<Unit>.Failure(Error.NotFound);

        UpdateColor(request, updatedColor, colorRepository);

        return await TrySaveChanges(cancellationToken);
    }

    private void UpdateColor(UpdateColorCommand request,
        VehicleColor updatedColor, IRepository<VehicleColor> colorRepository)
    {
        updatedColor.Name = request.UpdatedName;

        updatedColor.HexValue = request.UpdatedHexValue!;

        colorRepository.UpdateExistingEntityAsync(updatedColor);
    }
}