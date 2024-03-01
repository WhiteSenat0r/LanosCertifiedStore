using Application.Commands.Common;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Brands.DeleteBrand;

internal sealed class DeleteBrandCommandHandlerHandler : CommandHandlerBase<Unit>, IRequestHandler<DeleteBrandCommand, Result<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBrandCommandHandlerHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _unitOfWork = unitOfWork;
        PossibleErrors = new[]
        {
            new Error("DeleteBrandError", "Removing a brand was not successful!"),
            new Error("DeleteBrandError", "Error occured during the brand removal!")
        };
    }

    public async Task<Result<Unit>> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
    {
        var brandRepository = _unitOfWork.RetrieveRepository<VehicleBrand>();
        
        var removedBrand = await brandRepository.GetEntityByIdAsync(request.Id);
        
        if (removedBrand is null) return Result<Unit>.Failure(Error.NotFound);

        await RemoveBrandWithRelatedData(request.Id, removedBrand.Models, brandRepository);

        return await TrySaveChanges(cancellationToken);
    }

    private async Task RemoveBrandWithRelatedData(
        Guid removedBrandId, 
        IEnumerable<VehicleModel> relatedModels,
        IRepository<VehicleBrand> brandRepository)
    {
        var modelRepository = _unitOfWork.RetrieveRepository<VehicleModel>();
        
        foreach (var relatedModel in relatedModels)
            await modelRepository.RemoveExistingEntity(relatedModel.Id);

        await brandRepository.RemoveExistingEntity(removedBrandId);
    }
}