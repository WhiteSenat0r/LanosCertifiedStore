using System.ComponentModel.DataAnnotations;

namespace Domain.Contracts.Common;

public interface IIdentifiable<TKey> where TKey : struct
{
    [Key] public TKey Id { get; }
}