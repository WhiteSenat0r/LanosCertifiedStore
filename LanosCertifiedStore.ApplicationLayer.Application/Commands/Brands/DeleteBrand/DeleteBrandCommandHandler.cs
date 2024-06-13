using Application.Commands.Common;
using Application.Contracts.RepositoryRelated.Common;
using Application.Shared;
using Domain.Models.VehicleRelated.Classes;
using MediatR;

namespace Application.Commands.Brands.DeleteBrand;

internal sealed class DeleteBrandCommandHandler : CommandHandlerBase<Unit>, IRequestHandler<DeleteBrandCommand, Result<Unit>>
{
    public DeleteBrandCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        PossibleErrors =
        [
            new Error("DeleteBrandError", "Brand removal was not successful!"),
            new Error("DeleteBrandError", "Error occured during the brand removal!")
        ];
    }

    public async Task<Result<Unit>> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
    {
        var brandRepository = GetRequiredRepository<VehicleBrand>();
        
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
        var modelRepository = GetRequiredRepository<VehicleModel>();
        
        foreach (var relatedModel in relatedModels)
            await modelRepository.RemoveExistingEntityAsync(relatedModel.Id);

        await brandRepository.RemoveExistingEntityAsync(removedBrandId);
    }
}