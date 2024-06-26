﻿using System.Linq.Expressions;
using Persistence.DataModels.VehicleRelated.LocationRelated;

namespace Persistence.Repositories.LocationRelated.LocationAreaRelated.QueryBuilderRelated.Common.Classes;

internal abstract class VehicleLocationAreaSortingTypes
{
    public static readonly Dictionary<string, Expression<Func<VehicleLocationAreaDataModel, object>>> 
        Options = new()
    {
        { "name-asc", vehicleType => vehicleType.Name },
        { "name-desc", vehicleType => vehicleType.Name },
        { "default", vehicleType => vehicleType.Name }
    };
}