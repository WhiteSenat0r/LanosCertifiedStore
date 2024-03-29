﻿using Domain.Contracts.Common;

namespace Persistence.DataModels.UserRelated;

internal class UserRoleDataModel : IIdentifiable<Guid>
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; } = default!;
    public ICollection<UserDataModel> Users { get; set; } = new List<UserDataModel>();
    
    public UserRoleDataModel() { }

    public UserRoleDataModel(string name) => Name = name;

    public override string ToString() => Name;
}