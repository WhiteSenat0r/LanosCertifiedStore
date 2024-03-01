using Application.Commands.Common;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Colors.UpdateColor;

internal sealed class UpdateColorCommandHandler : CommandBase<Unit>, IRequestHandler<UpdateColorCommand, Result<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateColorCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _unitOfWork = unitOfWork;
        PossibleErrorMessages = 
            ["Saving an updated color was not successful!", "Error occured during the color update!"];
        PossibleErrorCode = "UpdateColorError";
    }

    public async Task<Result<Unit>> Handle(UpdateColorCommand request, CancellationToken cancellationToken)
    {
        var colorRepository = _unitOfWork.RetrieveRepository<VehicleColor>();
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

        colorRepository.UpdateExistingEntity(updatedColor);
    }
}