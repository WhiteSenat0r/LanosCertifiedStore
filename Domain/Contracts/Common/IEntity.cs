using System.ComponentModel.DataAnnotations;

namespace Domain.Contracts.Common;

public interface IEntity<TKey> where TKey : struct
{
    [Key] public TKey Id { get; set; }
}