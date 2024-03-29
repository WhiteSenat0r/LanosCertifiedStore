﻿using AutoMapper;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.UserRelated;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Identity.UserManagement.DeleteUser;

internal sealed class DeleteUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<DeleteUserCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.RetrieveRepository<User>().RemoveExistingEntityAsync(request.Id);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result
            ? Result<Unit>.Success(Unit.Value)
            : Result<Unit>.Failure(new Error("DeleteError", "Failed to delete error"));
    }
}